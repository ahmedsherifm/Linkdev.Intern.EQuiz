﻿using Linkdev.Intern.EQuiz.Data;
using Linkdev.Intern.EQuiz.Repo.Interfaces;
using Linkdev.Intern.EQuiz.Repo.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Linkdev.Intern.EQuiz.Repo.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public EQuizContext Context { get; private set; }

        public UnitOfWork(EQuizContext _context)
        {
            Context = _context;

            AnswerRepository = new AnswerRepository(_context);
            EmployeeQuestionTemplateRepository = new EmployeeQuestionTemplateRepository(_context);
            EmployeeRepository = new EmployeeRepository(_context);
            EmployeeTemplateRepository = new EmployeeTemplateRepository(_context);
            QuestionRepository = new QuestionRepository(_context);
            QuestionTemplateRepository = new QuestionTemplateRepository(_context);
            QuizRepository = new QuizRepository(_context);
            TemplateRepository = new TemplateRepository(_context);
            TopicRepository = new TopicRepository(_context);
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

        public void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
}