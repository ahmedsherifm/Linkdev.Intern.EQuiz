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
        private readonly IQuestionService questionService;

        public QuestionsController(IQuestionService questionService)
        {
            this.questionService = questionService;
        }
        public QuestionsController()
        {
            questionService = new QuestionService();
        }

        // How to use delegates with APIs???!!!!!!!!!!!!!ظظظظظظظظظ
        // not having enumerable quizes in questions (mapping occurs on third class)
        
        public IEnumerable<Question> Get()
        {
            var questions =  questionService.GetAllQuestions();

            return questions;
        }

        [Route("{id:int}")]
        public Question Get(int id)
        {
            var question = questionService.GetQuestionById(id);

            return question;
        }

        [HttpPost]
        public bool? AddQuestion([FromBody]Question question)
        {
            var result = questionService.Add(question);

            return result;
        }

        [Route("{pageIndex:int,pageSize:int}")]
        public IEnumerable<Question> GetQuestionsByCreationDate(int pageIndex, int pageSize = 10)
        {
            var questions = questionService.GetQuestionsByCreationDate(pageIndex, pageSize);

            return questions;
        }

        [Route("{pageIndex:int,pageSize:int,ascending:int}")]
        public IEnumerable<Question> GetQuestionsByName(bool ascending, int pageIndex, int pageSize = 10)
        {
            var questions = questionService.GetQuestionsByName(ascending, pageIndex, pageSize);

            return questions;
        }

        [Route("bytext/{pageIndex:int,pageSize:int,text:alpha}")]
        public IEnumerable<Question> FilterQuestionsByText(string text, int pageIndex, int pageSize = 10)
        {
            var questions = questionService.FilterQuestionsByText(text, pageIndex, pageSize);

            return questions;
        }
        // Can get Have body
        [HttpGet]
        [Route("bytopic/{pageIndex:int,pageSize:int}")]
        public IEnumerable<Question> GetQuestionsByTopic([FromBody] Topic topic, int pageIndex, int pageSize = 10)
        {
            var questions = questionService.GetQuestionsByTopic(topic, pageIndex, pageSize);

            return questions;
        }

        [Route("bytopic/{pageIndex:int,pageSize:int,topicName:alpha}")]
        public IEnumerable<Question> GetQuestionsByTopicName(string topicName, int pageIndex, int pageSize = 10)
        {
            var questions = questionService.GetQuestionsByTopicName(topicName, pageIndex, pageSize);

            return questions;
        }

        [Route("questionhint/{id:int}")]
        public string GetQuestionHint(int id)
        {
            var hint = questionService.GetQuestionHint(id);

            return hint;
        }

        [Route("questionanswers/{id:int}")]
        public IEnumerable<Answer> GetQuestionAnswers(int id)
        {
            var answers = questionService.GetQuestionAnswers(id);

            return answers;
        }

        [Route("questionquizes/{id:int}")]
        public IEnumerable<Quiz> GetQuestionQuizez(int id)
        {
            var quizes = questionService.GetQuestionQuizez(id);

            return quizes;
        }

        [Route("questiontopic/{id:int}")]
        public Topic GetQuestionTopic(int id)
        {
            var topic = questionService.GetQuestionTopic(id);

            return topic;
        }
    }
}
