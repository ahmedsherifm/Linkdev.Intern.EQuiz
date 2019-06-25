using Linkdev.Intern.EQuiz.Data.EntityFrameWork;
using Linkdev.Intern.EQuiz.Data.Repository.Interfaces;
using Linkdev.Intern.EQuiz.Data.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Linkdev.Intern.EQuiz.Data.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public EQuizContext Context { get; private set; } = new EQuizContext();

        public UnitOfWork()
        {
            AnswerRepository = new AnswerRepository(Context);
            EmployeeQuestionTemplateRepository = new EmployeeQuestionTemplateRepository(Context);
            EmployeeRepository = new EmployeeRepository(Context);
            EmployeeTemplateRepository = new EmployeeTemplateRepository(Context);
            QuestionRepository = new QuestionRepository(Context);
            QuestionTemplateRepository = new QuestionTemplateRepository(Context);
            QuizRepository = new QuizRepository(Context);
            TemplateRepository = new TemplateRepository(Context);
            TopicRepository = new TopicRepository(Context);
            QuestionQuizRepository = new QuestionQuizRepository(Context);
        }

        public IAnswerRepository AnswerRepository { get; set; }
        public IEmployeeQuestionTemplateRepository EmployeeQuestionTemplateRepository { get; set; }
        public IEmployeeRepository EmployeeRepository { get; set; }
        public IEmployeeTemplateRepository EmployeeTemplateRepository { get; set; }
        public IQuestionRepository QuestionRepository { get; set; }
        public IQuestionTemplateRepository QuestionTemplateRepository { get; set; }
        public IQuizRepository QuizRepository { get; set; }
        public ITemplateRepository TemplateRepository { get; set; }
        public ITopicRepository TopicRepository { get; set; }
        public IQuestionQuizRepository QuestionQuizRepository { get; set; }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}