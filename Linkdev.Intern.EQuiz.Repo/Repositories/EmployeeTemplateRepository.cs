using Linkdev.Intern.EQuiz.Data;
using Linkdev.Intern.EQuiz.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Linkdev.Intern.EQuiz.Repo.Repositories
{
    public class EmployeeTemplateRepository : Repository<Employees_Templates>, IEmployeeTemplateRepository
    {
        public EQuizContext EQuizContext
        {
            get
            {
                return Context as EQuizContext;
            }
        }

        public EmployeeTemplateRepository(EQuizContext context) : base(context)
        {
        }

        public IEnumerable<Employees_Templates> GetEmployeesTemplatesByQuestionId(int qid)
        {
            return EQuizContext.Employees_Templates
                .Include(et => et.Template)
                .Include(et => et.Template.Questions_Templates)
                .Where(et => et.Template.Questions_Templates
                .Any(qt => qt.QuestionID == qid))
                .AsEnumerable();
        }

        
}
}