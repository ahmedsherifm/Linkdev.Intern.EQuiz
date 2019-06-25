using Linkdev.Intern.EQuiz.Data.Domain;
using Linkdev.Intern.EQuiz.Data.Repository.Interfaces;
using Linkdev.Intern.EQuiz.Data.EntityFrameWork;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Linkdev.Intern.EQuiz.Mappers.Criteria;

namespace Linkdev.Intern.EQuiz.Data.Repository.Repositories
{

    public class TopicRepository : Repository<Topic>, ITopicRepository
    {
        public EQuizContext EQuizContext
        {
            get
            {
                return Context as EQuizContext;
            }
        }

        public TopicRepository(EQuizContext context) : base(context)
        {
        }

        public IEnumerable<Topic> FilterTopicsByName(string name, int pageIndex, int pageSize = 10)
        {
            return EQuizContext.Topics
                    .Where(t => t.Name.ToLower()
                    .Contains(name.ToLower()))
                    .Skip((pageIndex - 1) * pageSize) // what if page index = 1 ??
                    .Take(pageSize)
                    .AsEnumerable();
        }

        public IEnumerable<Topic> GetTopicsByCreationDate(int pageIndex, int pageSize = 10)
        {
            return EQuizContext.Topics
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .OrderByDescending(t => t.CreationDate)
                    .AsEnumerable();
        }

        public IEnumerable<Topic> GetTopicsByName(bool ascending, int pageIndex, int pageSize = 10)
        {
            if (ascending)
            { 
                return EQuizContext.Topics
                        .Skip((pageIndex - 1) * pageSize)
                        .Take(pageSize)
                        .OrderBy(t => t.Name);
            }
            else
            {
                return EQuizContext.Topics
                        .Skip((pageIndex - 1) * pageSize)
                        .Take(pageSize)
                        .OrderByDescending(t => t.Name);
            }
        }

        //public IEnumerable<Topic> GetTopics(int pageIndex, int pageSize = 10)
        //{
        //    return EQuizContext.Topics
        //            .Skip((pageIndex - 1) * pageSize)
        //            .Take(pageSize)
        //            .AsEnumerable();
        //}


        // get topic's questions and answers
        public IEnumerable<Question> GetTopicQuestions(int id)
        {
            return GetByID(id)
                   .Questions
                   .AsEnumerable();
        }

        // check topic has questions
        public bool? TopicHasQuestion(int id)
        {
            if (GetByID(id).Questions.Any() )
                return true;
            else
                return false;                   
        }

        // check topic has questions used
        public bool? TopicHasQuestionUsed(int id)
        {
            if(GetByID(id).Questions.Any(q => q.IsUsed))
                return true;
            else
                return false;
        }

        // change name
        public bool? ChangeTopicName(int id, string name)
        {
            var topic = GetByID(id);
            if (topic == null)
                return false;
            else
            {
               topic.Name = name;
                return true;
            }
        }

        public override bool? Remove(Topic entity)
        {
            if (entity != null)
            {
                entity.IsDeleted = true;
                entity.Questions.Select(q => { q.IsDeleted = true; return q; }).ToList();
                
                return true;
            }
            else
                return false;
        }

        public Topic GetTopicByQuestion(int qid)
        {
            return EQuizContext.Questions
                    .SingleOrDefault(q => q.ID == qid)
                    .Topic;
        }

        public override IEnumerable<Topic> Search(BaseCriteria baseCriteria)
        {
            var topicCriteria = baseCriteria as TopicCriteria;
            if (topicCriteria == null) return null;

            IQueryable<Topic> topics = GetAll().AsQueryable();

            if (topicCriteria.IsDeleted != null)
                topics = topics.Where(t => t.IsDeleted == topicCriteria.IsDeleted);

            if (topicCriteria.Name != null)
                topics = topics.Where(t => t.Name.ToLower().Contains(topicCriteria.Name.ToLower()));

            if(topicCriteria.CreationDate != null)
                topics = topics.Where(t => t.CreationDate == topicCriteria.CreationDate);

            if(topicCriteria.OrderDirection != null && topicCriteria.OrderType != null)
                switch (topicCriteria.OrderType)
                {
                    case OrderType.Name:
                        if(topicCriteria.OrderDirection == OrderDirection.Desending)
                            topics = topics.OrderByDescending(t=>t.Name);
                        else
                            topics = topics.OrderBy(t => t.Name);
                        break;

                    case OrderType.CreationDate:
                        if (topicCriteria.OrderDirection == OrderDirection.Desending)
                            topics = topics.OrderByDescending(t => t.CreationDate);
                        else
                            topics = topics.OrderBy(t => t.CreationDate);
                        break;

                    case OrderType.IsDeleted:
                        if (topicCriteria.OrderDirection == OrderDirection.Desending)
                            topics = topics.OrderByDescending(t => t.IsDeleted);
                        else
                            topics = topics.OrderBy(t => t.IsDeleted);
                        break;

                    default:
                        topics = topics.OrderBy(t => t.ID);
                        break;
                }


            if (topicCriteria.PageSize != null && topicCriteria.PageIndex != null)
                topics = topics
                    .Skip(((int)topicCriteria.PageIndex - 1) * (int)topicCriteria.PageSize)
                    .Take((int)topicCriteria.PageSize);

            return topics;
        }

    }
}