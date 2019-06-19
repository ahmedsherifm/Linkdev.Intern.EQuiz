using Linkdev.Intern.EQuiz.Data;
using Linkdev.Intern.EQuiz.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Linkdev.Intern.EQuiz.Repo.Repositories
{
    public class QuizRepository : Repository<Quiz>, IQuizRepository
    {
        public EQuizContext EQuizContext
        {
            get
            {
                return Context as EQuizContext;
            }
        }

        public QuizRepository(EQuizContext context) : base(context)
        {
        }

        public IEnumerable<Quiz> GetQuizesByQuestion(int qid)
        {
            return EQuizContext.Questions_Quizes
                    .Where(q => q.Question.ID == qid)
                    .Include(q => q.Quiz)
                    .Select(q => q.Quiz)
                    .AsEnumerable();
        }

        public IEnumerable<Answer> GetQuizAnswers(int id)
        {
            return EQuizContext.Answers
                .Include(a=>a.Question)
                .Include(a=>a.Question.Questions_Quizes)
                .Where(a => a.Question.Questions_Quizes
                .Any(qq => qq.QuizID == id))
                .AsEnumerable();
        }

        public bool? AssignEmployeesToQuiz(int id, ICollection<Employee> employees)
        {
            throw new NotImplementedException();
        }

        public bool? ReleaseQuizFromEmployees(int id, ICollection<Employee> employees)
        {
            throw new NotImplementedException();
        }

        public bool? AssignEmployeesToReTakeQuiz(int id, ICollection<Employee> employees)
        {
            throw new NotImplementedException();
        }

        public bool? ExtendExpirationDate(int id, DateTime expirationDate)
        {
            throw new NotImplementedException();
        }
    }
}