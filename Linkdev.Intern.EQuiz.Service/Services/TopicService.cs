using Linkdev.Intern.EQuiz.Mappers;
using Linkdev.Intern.EQuiz.Repo.UnitOfWork;
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
        private readonly IUnitOfWork UnitOfWork;

        public TopicService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
        public TopicService()
        {
            UnitOfWork =new UnitOfWork(new Data.EQuizContext());
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

        
        public Output CheckTopicStatus(int id)
        {         

            if (UnitOfWork.TopicRepository.TopicHasQuestion(id) == false)
                return Output.Success;
            else if (UnitOfWork.TopicRepository.TopicHasQuestionUsed(id) == false)
                return Output.Warning;
            else
                return Output.Failure;
        }

        public bool? RemoveTopic(int id)
        {
            var entity = GetTopicByID(id);
            if (entity != null)
            {
                var dtoTopic = DTOMapper.Mapper.Map<Topic, Data.Topic>(entity);
                UnitOfWork.TopicRepository.Remove(dtoTopic);
                UnitOfWork.SaveChanges();
                return true;
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

        public bool? ChangeTopicName(int id, string name)
        {
            var result = UnitOfWork.TopicRepository.ChangeTopicName(id, name);
            if ((bool)result)
            {
                UnitOfWork.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public IEnumerable<Question> GetTopicQuestions(int id)
        {
            var questions = UnitOfWork.TopicRepository.GetTopicQuestions(id);
            return DTOMapper.Mapper.Map<IEnumerable<Data.Question>, IEnumerable<Question>>(questions);
        }

       
    }
}