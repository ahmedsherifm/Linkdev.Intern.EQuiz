using Linkdev.Intern.EQuiz.Data;
using Linkdev.Intern.EQuiz.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Linkdev.Intern.EQuiz.Repo.Repositories
{
    public class QuestionRepository : Repository<Question>, IQuestionRepository
    {
        public QuestionRepository(EQuizContext context) : base(context)
        {
        }
    }
}