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

        public EmployeeTemplateStatus CheckTemplateStatusForEmployee(int templateID,int employeeID)
        {
            return EQuizContext.Employees_Templates
                .SingleOrDefault(et => et.TemplateID == templateID && et.EmployeeID == employeeID)
                .Status;
        }

        public bool? ChangeEmployeeTemplateStatus(EmployeeTemplateStatus newStatus,int employeeID,int templateID)
        {
            var employee = EQuizContext.Employees.SingleOrDefault(e => e.ID == employeeID);
            var template = EQuizContext.Templates.SingleOrDefault(t => t.ID == templateID);

            if (employee != null && template != null)
            {
                var oldStatus = EQuizContext.Employees_Templates.SingleOrDefault(et => et.EmployeeID == employeeID && et.TemplateID == templateID).Status;
                oldStatus = newStatus;

                return true;
            }
            else
                return false;
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