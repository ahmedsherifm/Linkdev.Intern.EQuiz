using Linkdev.Intern.EQuiz.Data;
using Linkdev.Intern.EQuiz.Repo.Interfaces;
using Linkdev.Intern.EQuiz.Repo.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Linkdev.Intern.EQuiz.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly EQuizContext context;

        IAnswerRepository answerRepository;

        public UnitOfWork(EQuizContext _context)
        {
            context = _context;
        }



        void IUnitOfWork.SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}