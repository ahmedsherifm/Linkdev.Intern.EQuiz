using Linkdev.Intern.EQuiz.Mappers;
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
    [RoutePrefix("api/questions")]
    public class QuestionsController : ApiController
    {
        private readonly IQuestionService _questionService;

        public QuestionsController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        public QuestionsController()
        {
            _questionService = new QuestionService();
        }

        [HttpPatch]
        [Route("edit/{quesId:int}")]
        public bool ChangeQuestionAnswers([FromUri]int quesId, [FromBody] ICollection<Answer> answers)
        {
            return _questionService.ChangeCorrectAnswers(quesId, answers);
        }

        [HttpPut]
        [Route("edit")]
        public bool EditQuestion([FromBody]Question question)
        {
            return _questionService.EditQuestion(question);
        }

        [HttpGet]
        [Route("usedStatus/{id:int}")]
        public bool CheckIsQuestionUsed(int id)
        {
            return _questionService.IsQuestionUsed(id);
        }

        [HttpGet]
        [Route("activeStatus/{id:int}")]
        public bool CheckIsQuestionActive(int id)
        {
            return _questionService.IsQuestionActive(id);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public bool RemoveQuestion(int id)
        {
            return _questionService.Remove(id);
        }
    }
}
