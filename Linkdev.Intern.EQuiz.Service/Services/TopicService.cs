﻿using Linkdev.Intern.EQuiz.Mappers;
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
            var dtoPredict = DTOMapper.Mapper.Map<Expression<Func<Topic, bool>>, Expression<Func<Data.Topic, bool>>>(predict);
            var topics = UnitOfWork.TopicRepository.Find(dtoPredict);
            return DTOMapper.Mapper.Map<IEnumerable<Data.Topic>, IEnumerable<Topic>>(topics);
        }

        public IEnumerable<Topic> GetAllTopics()
        {
            var topics = UnitOfWork.TopicRepository.GetAll();
            return DTOMapper.Mapper.Map<IEnumerable<Data.Topic>, IEnumerable<Topic>>(topics);
        }

        public Topic GetTopicByID(int id)
        {
            var topic = UnitOfWork.TopicRepository.GetByID(id);

            return DTOMapper.Mapper.Map<Data.Topic, Topic>(topic);
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
            var dtoPredict = DTOMapper.Mapper.Map<Expression<Func<Topic, bool>>, Expression<Func<Data.Topic, bool>>>(predict);
            var topics = UnitOfWork.TopicRepository.SingleOrDefault(dtoPredict);
            return DTOMapper.Mapper.Map<Data.Topic, Topic>(topics);
        }

        public IEnumerable<Topic> GetTopicsByCreationDate(int pageIndex, int pageSize = 10)
        {
            var topics = UnitOfWork.TopicRepository.GetTopicsByCreationDate(pageIndex,pageSize);
            return DTOMapper.Mapper.Map<IEnumerable<Data.Topic>, IEnumerable<Topic>>(topics);
        }

        public IEnumerable<Topic> GetTopicsByName(bool ascending, int pageIndex, int pageSize = 10)
        {
            var topics = UnitOfWork.TopicRepository.GetTopicsByName(ascending,pageIndex, pageSize);
            return DTOMapper.Mapper.Map<IEnumerable<Data.Topic>, IEnumerable<Topic>>(topics);
        }

        public IEnumerable<Topic> FilterTopicsByName(string name, int pageIndex, int pageSize = 10)
        {
            var topics = UnitOfWork.TopicRepository.FilterTopicsByName(name,pageIndex, pageSize);
            return DTOMapper.Mapper.Map<IEnumerable<Data.Topic>, IEnumerable<Topic>>(topics);
        }
    }
}