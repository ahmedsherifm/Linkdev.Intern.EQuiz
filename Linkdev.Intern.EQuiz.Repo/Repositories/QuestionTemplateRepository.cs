using Linkdev.Intern.EQuiz.Data.Domain;
using Linkdev.Intern.EQuiz.Data.Repository.Interfaces;
using Linkdev.Intern.EQuiz.Data.EntityFrameWork;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Linkdev.Intern.EQuiz.Data.Repository.Repositories
{
    public class QuestionTemplateRepository : Repository<Questions_Templates>, IQuestionTemplateRepository
    {
        public QuestionTemplateRepository(EQuizContext context) : base(context)
        {
        }
    }
}