using Linkdev.Intern.EQuiz.Shared;
using Linkdev.Intern.EQuiz.Service.BusinessUnity;
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
        
        [HttpGet]
        [Route("{id:int}")]
        // GET: api/Quizes/5
        public QuizDTO GetQuizByID(int id)
        {
            return BusinessUnity.QuizService.GetQuizByID(id);
        }
        
        [HttpGet]
        [Route("question/{qid:int}")]
        public IEnumerable<QuizDTO> GetQuizesByQuestionID(int qid)
        {
            return BusinessUnity.QuizService.GetQuizesByQuestionID(qid);
        }

        [HttpGet]
        [Route("~/api/answers/quiz/{id:int}")]
        public IEnumerable<AnswerDTO> GetQuizAnswers(int id)
        {
            return BusinessUnity.QuizService.GetQuizAnswers(id);
        }

        [HttpPost]
        [Route("expiredate/{id:int}")]
        public bool ExtendExpirationDate([FromUri]int id,[FromBody] DateTime expirationDate)
        {
            return BusinessUnity.QuizService.ExtendExpirationDate(id, expirationDate);
        }

        [HttpPost]
        [Route("deactivate/{id:int}")]
        public bool DeactivateQuiz(int id)
        {
            return BusinessUnity.QuizService.DeactivateQuiz(id);
        }

        [HttpPost]
        [Route("deactivate")]
        public bool DeactivateQuizesList([FromBody]ICollection<int> quizesIds)
        {
            return BusinessUnity.QuizService.DeactivateQuizesList(quizesIds);
        }

        [HttpPost]
        [Route("activate/{id:int}")]
        public bool ActivateQuiz(int id)
        {
            return BusinessUnity.QuizService.ActivateQuiz(id);
        }

        [HttpPost]
        [Route("{id:int}/trials")]
        public bool UpdateNumberOfTrials([FromUri] int id,[FromBody] int numberOfTrials)
        {
            return BusinessUnity.QuizService.UpdateNumberOfTrials(id, numberOfTrials);
        }

        [HttpPost]
        [Route("{id:int}/passingScore")]
        public bool UpdatePassingScore([FromUri]int id,[FromBody] int passingScore)
        {
            return BusinessUnity.QuizService.UpdatePassingScore(id, passingScore);
        }

        [HttpPost]
        [Route("{id:int}/name")]
        public bool ChangeQuizName([FromUri]int id,[FromBody] string name)
        {
            return BusinessUnity.QuizService.ChangeQuizName(id, name);
        }

        [HttpGet]
        [Route("activeStatus/{id:int}")]
        public bool CheckIsQuizActive(int id)
        {
            return BusinessUnity.QuizService.IsQuizActive(id);
        }

        [HttpPost]
        [Route("removelist")]
        public bool RemoveSelectedDeactivatedQuizesList([FromBody] ICollection<int> quizesIds)
        {
            return BusinessUnity.QuizService.RemoveSelectedDeactivatedQuizesList(quizesIds);
        }

        [HttpPost]
        [Route("")]
        public bool? CreateQuiz([FromBody] QuizDTO quiz)
        {
            return BusinessUnity.QuizService.CreateQuiz(quiz);
        }

        [HttpPost]
        [Route("addQuestions/{quizId:int}")]
        public bool? AddQuestionsToQuiz([FromUri]int quizId,[FromBody] IEnumerable<int> questionsIds)
        {
            return BusinessUnity.QuizService.AddQuestionsToQuiz(quizId,questionsIds);
        }

        [HttpPost]
        [Route("releaseEmployee/{quizId:int}/{employeeId:int}")]
        public bool ReleaseQuizFromEmployee(int quizId, int employeeId)
        {
            return BusinessUnity.QuizService.ReleaseQuizFromEmployee(quizId, employeeId);
        }

        [HttpPost]
        [Route("releaseEmployees/{quizId:int}")]
        public ICollection<bool> ReleaseQuizFromEmployee([FromUri]int quizId,[FromBody] ICollection<int> employeesIds)
        {
            return BusinessUnity.QuizService.ReleaseQuizFromEmployees(quizId, employeesIds);
        }
    }
}
