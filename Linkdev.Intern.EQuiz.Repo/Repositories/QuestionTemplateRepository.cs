using Linkdev.Intern.EQuiz.Data;
using Linkdev.Intern.EQuiz.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Linkdev.Intern.EQuiz.Repo.Repositories
{
    public class QuestionTemplateRepository : Repository<Questions_Templates>, IQuestionTemplateRepository
    {
        public QuestionTemplateRepository(EQuizContext context) : base(context)
        {
        }
    }
}