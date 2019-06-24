using Linkdev.Intern.EQuiz.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linkdev.Intern.EQuiz.Data.Repository.Interfaces
{
    public interface IEmployeeTemplateRepository : IRepository<Employees_Templates>
    {
        EmployeeTemplateStatus CheckTemplateStatusForEmployee(int templateID, int employeeID);

        bool? ChangeEmployeeTemplateStatus(EmployeeTemplateStatus newStatus, int employeeID, int templateID);
        IEnumerable<Employees_Templates> GetEmployeesTemplatesByQuestionId(int qid);

    }
}
