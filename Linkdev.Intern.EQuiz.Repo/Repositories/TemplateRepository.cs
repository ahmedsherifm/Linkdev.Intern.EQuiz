using Linkdev.Intern.EQuiz.Data;
using Linkdev.Intern.EQuiz.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Linkdev.Intern.EQuiz.Repo.Repositories
{
    public class TemplateRepository : Repository<Template>, ITemplateRepository
    {
        public TemplateRepository(EQuizContext context) : base(context)
        {
        }
    }
}