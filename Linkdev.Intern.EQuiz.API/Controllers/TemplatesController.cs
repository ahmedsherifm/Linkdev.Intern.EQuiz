using Linkdev.Intern.EQuiz.Service.BusinessUnity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Linkdev.Intern.EQuiz.API.Controllers
{
    [RoutePrefix("api/templates")]
    public class TemplatesController : ApiController
    {
       

        [HttpPost]
        [Route("createEmpty/{quizId:int}/{employeeId:int}")]
        public bool CreateEmptyTemplateToAssignedEmployee(int quizId, int employeeId)
        {
            return (bool)BusinessUnity.TemplateService.CreateEmptyTemplateToAssignedEmployee(quizId, employeeId);
        }

        [HttpPost]
        [Route("createEmpty/{quizId:int}")]
        public ICollection<bool> CreateEmptyTemplateToAssignedEmployee(int quizId, ICollection<int> employeeIds)
        {
            return BusinessUnity.TemplateService.CreateEmptyTemplatesToAssignedEmployees(quizId, employeeIds);
        }

        [HttpPost]
        [Route("takeTemplate/{quizId:int}/{employeeId:int}/{templateId:int}")]
        public bool EmployeeTakeTemplate(int employeeId, int quizId, int templateId)
        {
            return (bool)BusinessUnity.TemplateService.EmployeeTakeTemplate(employeeId, quizId, templateId);
        }
    }
}
