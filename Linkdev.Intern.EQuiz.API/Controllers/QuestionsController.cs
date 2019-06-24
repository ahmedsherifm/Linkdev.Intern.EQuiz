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

        // How to use delegates with APIs???!!!!!!!!!!!!!ظظظظظظظظظ
        // not having enumerable quizes in questions (mapping occurs on third class)
        
        public IEnumerable<Question> Get()
        {
            var questions =  _questionService.GetAllQuestions();

            return questions;
        }

        [Route("{id:int}")]
        public Question Get(int id)
        {
            var question = _questionService.GetQuestionById(id);

            return question;
        }

        [HttpPost]
        public bool? AddQuestion([FromBody]Question question)
        {
            var result = _questionService.Add(question);

            return result;
        }

        [Route("{pageIndex:int}/{pageSize:int}")]
        public IEnumerable<Question> GetQuestionsByCreationDate(int pageIndex, int pageSize = 10)
        {
            var questions = _questionService.GetQuestionsByCreationDate(pageIndex, pageSize);

            return questions;
        }

        [Route("{pageIndex:int}/{pageSize:int}/{ascending:int}")]
        public IEnumerable<Question> GetQuestionsByName(bool ascending, int pageIndex, int pageSize = 10)
        {
            var questions = _questionService.GetQuestionsByName(ascending, pageIndex, pageSize);

            return questions;
        }

        [Route("bytext/{pageIndex:int}/{pageSize:int}/{text:alpha}")]
        public IEnumerable<Question> FilterQuestionsByText(string text, int pageIndex, int pageSize = 10)
        {
            var questions = _questionService.FilterQuestionsByText(text, pageIndex, pageSize);

            return questions;
        }
        // Can get Have body
        [HttpGet]
        [Route("bytopic/{pageIndex:int}/{pageSize:int}")]
        public IEnumerable<Question> GetQuestionsByTopic([FromBody] Topic topic, int pageIndex, int pageSize = 10)
        {
            var questions = _questionService.GetQuestionsByTopic(topic, pageIndex, pageSize);

            return questions;
        }

        [Route("bytopic/{pageIndex:int}/{pageSize:int}/{topicName:alpha}")]
        public IEnumerable<Question> GetQuestionsByTopicName(string topicName, int pageIndex, int pageSize = 10)
        {
            var questions = _questionService.GetQuestionsByTopicName(topicName, pageIndex, pageSize);

            return questions;
        }

        [Route("questionhint/{id:int}")]
        public string GetQuestionHint(int id)
        {
            var hint = _questionService.GetQuestionHint(id);

            return hint;
        }

        [Route("questionanswers/{id:int}")]
        public IEnumerable<Answer> GetQuestionAnswers(int id)
        {
            var answers = _questionService.GetQuestionAnswers(id);

            return answers;
        }

        [Route("questioncorrectanswers/{id:int}")]
        public IEnumerable<Answer> GetCorrectQuestionAnswers(int id)
        {
            var answers = _questionService.GetCorrectQuestionAnswers(id);

            return answers;
        }

        [Route("questionquizes/{id:int}")]
        public IEnumerable<Quiz> GetQuestionQuizez(int id)
        {
            var quizes = _questionService.GetQuestionQuizez(id);

            return quizes;
        }

        [Route("questiontopic/{id:int}")]
        public Topic GetQuestionTopic(int id)
        {
            var topic = _questionService.GetQuestionTopic(id);

            return topic;
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