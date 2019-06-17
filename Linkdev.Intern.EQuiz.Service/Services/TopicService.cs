using Linkdev.Intern.EQuiz.Mappers;
using Linkdev.Intern.EQuiz.Repo.UnitOfWork;
using Linkdev.Intern.EQuiz.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Linkdev.Intern.EQuiz.Service.Services
{
    public class TopicService : ITopicService
    {
        private readonly IUnitOfWork UnitOfWork;

        public TopicService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public bool? AddTopic(Topic entity)
        {
            if (entity != null)
            {
                var dtoTopic = DTOMapper.Mapper.Map<Topic, Data.Topic>(entity);

                return UnitOfWork.TopicRepository.Add(dtoTopic);
            }
            else
                return false;
        }

        public IEnumerable<Topic> FindTopic(Expression<Func<Topic, bool>> predict)
        {
            //var topics = DTOMapper.Mapper.Map<IEnumerable<Topic>,IEnumerable<Data.Topic>
            throw new NotImplementedException();
        }

        public IEnumerable<Topic> GetAllTopics()
        {
            throw new NotImplementedException();
        }

        public Topic GetTopicByID(int id)
        {
            var topic = UnitOfWork.TopicRepository.GetByID(id);

            return DTOMapper.Mapper.Map< Data.Topic, Topic>(topic);
        }

        public bool? RemoveTopic(Topic entity)
        {
            if (entity != null)
            {
                var dtoTopic = DTOMapper.Mapper.Map<Topic, Data.Topic>(entity);

                return UnitOfWork.TopicRepository.Remove(dtoTopic);
            }
            else
                return false;
        }

        public Topic GetTopicSingleOrDefault(Expression<Func<Topic, bool>> predict)
        {
            //var topic = UnitOfWork.TopicRepository.SingleOrDefault(predict);

            //return DTOMapper.Mapper.Map<Data.Topic, Topic>(topic);
            throw new NotImplementedException();
        }
    }
}