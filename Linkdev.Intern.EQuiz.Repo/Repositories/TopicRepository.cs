using Linkdev.Intern.EQuiz.Data;
using Linkdev.Intern.EQuiz.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Linkdev.Intern.EQuiz.Repo.Repositories
{
    public enum TopicQuestionsState
    {
        NoQuestionsAssigned,NoQuestionsUsed,QuestionsUsed
    }


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

        public IEnumerable<Topic> GetTopics(int pageIndex, int pageSize = 10)
        {
            return EQuizContext.Topics
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .AsEnumerable();
        }


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



        //// delete topic " with all req. conds."
        //public TopicQuestionsState DeleteTopicStates(int id)
        //{
        //    if (TopicHasQuestion(id) == false)
        //        return TopicQuestionsState.NoQuestionsAssigned;
        //    else if (TopicHasQuestionUsed(id) == false)
        //        return TopicQuestionsState.NoQuestionsUsed;
        //    else
        //        return TopicQuestionsState.QuestionsUsed;
        //}
    }
}