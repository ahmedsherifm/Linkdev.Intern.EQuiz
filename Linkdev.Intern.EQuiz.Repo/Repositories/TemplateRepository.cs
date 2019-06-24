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

        public IEnumerable<Template> GetTemplatesByEmployeeId(int employeeId)
        {
            return EQuizContext.Templates
                .Where(t => t.EmployeeID == employeeId)
                .AsEnumerable();
        }

        public IEnumerable<Template> GetTemplatesByEmployeeAndQuizIds(int quizId,int employeeId)
        {
            return EQuizContext.Templates
                .Where(t => t.EmployeeID == employeeId && t.QuizID == quizId)
                .AsEnumerable();
        }
    }
}