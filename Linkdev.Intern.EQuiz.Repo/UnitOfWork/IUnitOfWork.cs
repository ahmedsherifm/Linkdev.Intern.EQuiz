using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Linkdev.Intern.EQuiz.Data.Repository.Interfaces;

namespace Linkdev.Intern.EQuiz.Data.Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        IAnswerRepository AnswerRepository { get; set; }

        IEmployeeQuestionTemplateRepository EmployeeQuestionTemplateRepository { get; set; }

        IEmployeeRepository EmployeeRepository { get; set; }

        IEmployeeTemplateRepository EmployeeTemplateRepository { get; set; }

        IQuestionRepository QuestionRepository { get; set; }

        IQuestionTemplateRepository QuestionTemplateRepository { get; set; }

        IQuizRepository QuizRepository { get; set; }

        ITemplateRepository TemplateRepository { get; set; }

        ITopicRepository TopicRepository { get; set; }

        IQuestionQuizRepository QuestionQuizRepository { get; set; }

        void SaveChanges();
    }
}
