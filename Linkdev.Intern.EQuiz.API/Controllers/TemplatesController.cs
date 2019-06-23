using Linkdev.Intern.EQuiz.Service.Interfaces;
using Linkdev.Intern.EQuiz.Service.Services;
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
        private readonly ITemplateService _templateService;

        public TemplatesController(ITemplateService templateService)
        {
            _templateService = templateService;
        }
        public TemplatesController()
        {
            _templateService = new TemplateService();
        }

        [HttpPost]
        [Route("createEmpty/{quizId:int}/{employeeId:int}")]
        public bool CreateEmptyTemplateToAssignedEmployee(int quizId, int employeeId)
        {
            return (bool)_templateService.CreateEmptyTemplateToAssignedEmployee(quizId, employeeId);
        }

        [HttpPost]
        [Route("takeTemplate/{quizId:int}/{employeeId:int}/{templateId:int}")]
        public bool EmployeeTakeTemplate(int employeeId, int quizId, int templateId)
        {
            return (bool)_templateService.EmployeeTakeTemplate(employeeId, quizId, templateId);
        }
    }
}
