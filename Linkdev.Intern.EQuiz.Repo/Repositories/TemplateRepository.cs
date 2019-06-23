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
        public EQuizContext EQuizContext
        {
            get
            {
                return Context as EQuizContext;
            }
        }
        public TemplateRepository(EQuizContext context) : base(context)
        {
        }

        public IEnumerable<Template> GetTemplatesByQuestionId(int qid)
        {
            return EQuizContext.Templates
                .Include(t => t.Questions_Templates)
                .Where(t => t.Questions_Templates.Any(qt => qt.QuestionID == qid))
                .AsEnumerable();
        }

        // no need to generate random here it will be in service
       
    }
}