using Linkdev.Intern.EQuiz.Data.Domain;
using Linkdev.Intern.EQuiz.Data.Repository.Interfaces;
using Linkdev.Intern.EQuiz.Data.EntityFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Linkdev.Intern.EQuiz.Data.Repository.Repositories
{
    public class AnswerRepository : Repository<Answer>, IAnswerRepository
    {
        public EQuizContext EQuizContext
        {
            get
            {
                return Context as EQuizContext;
            }
        }

        public AnswerRepository(EQuizContext context) : base(context)
        {
        }

        public IEnumerable<Answer> GetAnswersByQuestion(int qid)
        {
            return EQuizContext.Questions
                    .SingleOrDefault(q => q.ID == qid)
                    .Answers
                    .AsEnumerable();
        }

        public IEnumerable<Answer> GetCorrectAnswersByQuestion(int qid)
        {
            return EQuizContext.Questions
                    .SingleOrDefault(q => q.ID == qid)
                    .Answers
                    .Where(a => a.IsCorrect == true)
                    .AsEnumerable();
        }

    }
}