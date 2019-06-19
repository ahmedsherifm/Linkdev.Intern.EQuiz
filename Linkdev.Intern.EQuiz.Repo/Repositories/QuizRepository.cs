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

        
    }
}