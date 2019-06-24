using Linkdev.Intern.EQuiz.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linkdev.Intern.EQuiz.Service.Interfaces
{
    public interface ITemplateService
    {
        bool? CreateEmptyTemplateToAssignedEmployee(int quizId, int employeeId);
        bool? EmployeeTakeTemplate(int employeeID, int quizID, int templateID);
        bool? CreateEmptyTemplatesToAssignedEmployees(int quizId, ICollection<int> employeeIds);
    }
}
