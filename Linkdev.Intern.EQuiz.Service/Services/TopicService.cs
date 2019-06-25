using Linkdev.Intern.EQuiz.Shared;
using Linkdev.Intern.EQuiz.Data.Repository.UnitOfWork;
using Linkdev.Intern.EQuiz.Service.Interfaces;
using Linkdev.Intern.EQuiz.Service.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Linkdev.Intern.EQuiz.Service.Services
{
    public class TopicService : ITopicService
    {
        

        public bool? AddTopic(TopicDTO entity)
        {
            if (entity != null)
            {
                using (var UnitOfWork = new UnitOfWork())
                {
                    var dtoTopic = SMapper.Map(entity);
                    var result = UnitOfWork.TopicRepository.Add(dtoTopic);
                    UnitOfWork.SaveChanges();

                    return result;
                }
            }
            else
                return false;
        }

        //public IEnumerable<Topic> FindTopic(Expression<Func<Topic, bool>> predict)
        //{
        //    var dtoPredict = SMapper.Map(predict);
        //    var topics = UnitOfWork.TopicRepository.Find(dtoPredict);
        //    return DTOMapper.Mapper.Map<IEnumerable<Data.Domain.Topic>, IEnumerable<Topic>>(topics);
        //}

        public IEnumerable<TopicDTO> GetAllTopics()
        {
            using (var UnitOfWork = new UnitOfWork())
            {
                var topics = UnitOfWork.TopicRepository.GetAll();
                return SMapper.Map(topics.ToList());
            }
        }

        public TopicDTO GetTopicByID(int id)
        {
            using (var UnitOfWork = new UnitOfWork())
            {
                var topic = UnitOfWork.TopicRepository.GetByID(id);

                return SMapper.Map(topic);
            }
        }


        public Output CheckTopicStatus(int id)
        {
            using (var UnitOfWork = new UnitOfWork())
            {
                if (UnitOfWork.TopicRepository.TopicHasQuestion(id) == false)
                    return Output.Success;
                else if (UnitOfWork.TopicRepository.TopicHasQuestionUsed(id) == false)
                    return Output.Warning;
                else
                    return Output.Failure;
            }
        }

        public bool? RemoveTopic(int id)
        {
            var entity = GetTopicByID(id);
            if (entity != null)
            {
                using (var UnitOfWork = new UnitOfWork())
                {
                    var dtoTopic = SMapper.Map(entity);
                    var result = UnitOfWork.TopicRepository.Remove(dtoTopic);
                    UnitOfWork.SaveChanges();

                    return result;
                }
            }
            else
                return false;
        }

        //public Topic GetTopicSingleOrDefault(Expression<Func<Topic, bool>> predict)
        //{
        //    var dtoPredict = DTOMapper.Mapper.Map<Expression<Func<Topic, bool>>, Expression<Func<Data.Domain.Topic, bool>>>(predict);
        //    var topics = UnitOfWork.TopicRepository.SingleOrDefault(dtoPredict);
        //    return DTOMapper.Mapper.Map<Data.Domain.Topic, Topic>(topics);
        //}

        public IEnumerable<TopicDTO> GetTopicsByCreationDate(int pageIndex, int pageSize = 10)
        {
            using (var UnitOfWork = new UnitOfWork())
            {
                var topics = UnitOfWork.TopicRepository.GetTopicsByCreationDate(pageIndex, pageSize);
                return SMapper.Map(topics.ToList());
            }
        }

        public IEnumerable<TopicDTO> GetTopicsByName(bool ascending, int pageIndex, int pageSize = 10)
        {
            using (var UnitOfWork = new UnitOfWork())
            {
                var topics = UnitOfWork.TopicRepository.GetTopicsByName(ascending, pageIndex, pageSize);
                return SMapper.Map(topics.ToList());
            }
        }

        public IEnumerable<TopicDTO> FilterTopicsByName(string name, int pageIndex, int pageSize = 10)
        {
            using (var UnitOfWork = new UnitOfWork())
            {
                var topics = UnitOfWork.TopicRepository.FilterTopicsByName(name, pageIndex, pageSize);
                return SMapper.Map(topics.ToList());
            }
        }

        public bool? ChangeTopicName(int id, string name)
        {
            using (var UnitOfWork = new UnitOfWork())
            {
                var result = UnitOfWork.TopicRepository.ChangeTopicName(id, name);
                if ((bool)result)
                {
                    UnitOfWork.SaveChanges();
                    return result;
                }
                else
                    return false;
            }
        }

        public IEnumerable<QuestionDTO> GetTopicQuestions(int id)
        {
            using (var UnitOfWork = new UnitOfWork())
            {
                var questions = UnitOfWork.TopicRepository.GetTopicQuestions(id);
                return SMapper.Map(questions.ToList());
            }
        }

       
    }
}