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
    [RoutePrefix("api/quizes")]
    public class QuizesController : ApiController
    {
        private readonly IQuizService _quizService;

        public QuizesController(IQuizService quizService)
        {
            _quizService = quizService;
        }
        public QuizesController()
        {
            _quizService = new QuizService();
        }

        [HttpGet]
        [Route("{id:int}")]
        // GET: api/Quizes/5
        public Quiz GetQuizByID(int id)
        {
            return _quizService.GetQuizByID(id);
        }
        
        [HttpGet]
        [Route("question/{qid:int}")]
        public IEnumerable<Quiz> GetQuizesByQuestionID(int qid)
        {
            return _quizService.GetQuizesByQuestionID(qid);
        }

        [HttpGet]
        [Route("~/api/answers/quiz/{id:int}")]
        public IEnumerable<Answer> GetQuizAnswers(int id)
        {
            return _quizService.GetQuizAnswers(id);
        }

        [HttpPost]
        [Route("expiredate/{id:int}")]
        public bool ExtendExpirationDate([FromUri]int id,[FromBody] DateTime expirationDate)
        {
            return _quizService.ExtendExpirationDate(id, expirationDate);
        }

        [HttpPost]
        [Route("deactivate/{id:int}")]
        public bool DeactivateQuiz(int id)
        {
            return _quizService.DeactivateQuiz(id);
        }

        [HttpPost]
        [Route("deactivate")]
        public bool DeactivateQuizesList([FromBody]ICollection<int> quizesIds)
        {
            return _quizService.DeactivateQuizesList(quizesIds);
        }

        [HttpPost]
        [Route("activate/{id:int}")]
        public bool ActivateQuiz(int id)
        {
            return _quizService.ActivateQuiz(id);
        }

        [HttpPost]
        [Route("{id:int}/trials")]
        public bool UpdateNumberOfTrials([FromUri] int id,[FromBody] int numberOfTrials)
        {
            return _quizService.UpdateNumberOfTrials(id, numberOfTrials);
        }

        [HttpPost]
        [Route("{id:int}/passingScore")]
        public bool UpdatePassingScore([FromUri]int id,[FromBody] int passingScore)
        {
            return _quizService.UpdatePassingScore(id, passingScore);
        }

        [HttpPost]
        [Route("{id:int}/name")]
        public bool ChangeQuizName([FromUri]int id,[FromBody] string name)
        {
            return _quizService.ChangeQuizName(id, name);
        }

        [HttpGet]
        [Route("activeStatus/{id:int}")]
        public bool CheckIsQuizActive(int id)
        {
            return _quizService.IsQuizActive(id);
        }

        [HttpPost]
        [Route("removelist")]
        public bool RemoveSelectedDeactivatedQuizesList([FromBody] ICollection<int> quizesIds)
        {
            return _quizService.RemoveSelectedDeactivatedQuizesList(quizesIds);
        }

        [HttpPost]
        [Route("")]
        public bool? CreateQuiz([FromBody] Quiz quiz)
        {
            return _quizService.CreateQuiz(quiz);
        }

        [HttpPost]
        [Route("addQuestions/{quizId:int}")]
        public bool? AddQuestionsToQuiz([FromUri]int quizId,[FromBody] IEnumerable<int> questionsIds)
        {
            return _quizService.AddQuestionsToQuiz(quizId,questionsIds);
        }

        [HttpPost]
        [Route("releaseEmployee/{quizId:int}/{employeeId:int}")]
        public bool ReleaseQuizFromEmployee(int quizId, int employeeId)
        {
            return _quizService.ReleaseQuizFromEmployee(quizId, employeeId);
        }

        [HttpPost]
        [Route("releaseEmployees/{quizId:int}")]
        public ICollection<bool> ReleaseQuizFromEmployee([FromUri]int quizId,[FromBody] ICollection<int> employeesIds)
        {
            return _quizService.ReleaseQuizFromEmployees(quizId, employeesIds);
        }
    }
}
