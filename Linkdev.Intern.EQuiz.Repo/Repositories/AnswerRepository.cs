using Linkdev.Intern.EQuiz.Data;
using Linkdev.Intern.EQuiz.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Linkdev.Intern.EQuiz.Repo.Repositories
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
    }
}