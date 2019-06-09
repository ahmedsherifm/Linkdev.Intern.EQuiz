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

        public bool? Add(Topic entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Topic> Find(Expression<Func<Topic, bool>> predict)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Topic> GetAll()
        {
            throw new NotImplementedException();
        }

        public Topic GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public bool? Remove(Topic entity)
        {
            throw new NotImplementedException();
        }

        public Topic SingleOrDefault(Expression<Func<Topic, bool>> predict)
        {
            throw new NotImplementedException();
        }
    }
}