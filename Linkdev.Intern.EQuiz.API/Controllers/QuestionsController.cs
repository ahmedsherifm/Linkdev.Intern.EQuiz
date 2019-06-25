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
    [RoutePrefix("api/questions")]
    public class QuestionsController : ApiController
    {
        
        public IEnumerable<QuestionDTO> Get()
        {
            var questions = BusinessUnity.QuestionService.GetAllQuestions();

            return questions;
        }

        [Route("{id:int}")]
        public QuestionDTO Get(int id)
        {
            var question = BusinessUnity.QuestionService.GetQuestionById(id);

            return question;
        }

        [HttpPost]
        public bool? AddQuestion([FromBody]QuestionDTO question)
        {
            var result = BusinessUnity.QuestionService.Add(question);

            return result;
        }

        [Route("{pageIndex:int}/{pageSize:int}")]
        public IEnumerable<QuestionDTO> GetQuestionsByCreationDate(int pageIndex, int pageSize = 10)
        {
            var questions = BusinessUnity.QuestionService.GetQuestionsByCreationDate(pageIndex, pageSize);

            return questions;
        }

        [Route("{pageIndex:int}/{pageSize:int}/{ascending:int}")]
        public IEnumerable<QuestionDTO> GetQuestionsByName(bool ascending, int pageIndex, int pageSize = 10)
        {
            var questions = BusinessUnity.QuestionService.GetQuestionsByName(ascending, pageIndex, pageSize);

            return questions;
        }

        [Route("bytext/{pageIndex:int}/{pageSize:int}/{text:alpha}")]
        public IEnumerable<QuestionDTO> FilterQuestionsByText(string text, int pageIndex, int pageSize = 10)
        {
            var questions = BusinessUnity.QuestionService.FilterQuestionsByText(text, pageIndex, pageSize);

            return questions;
        }
        // Can get Have body
        [HttpGet]
        [Route("bytopic/{pageIndex:int}/{pageSize:int}")]
        public IEnumerable<QuestionDTO> GetQuestionsByTopic([FromBody] TopicDTO topic, int pageIndex, int pageSize = 10)
        {
            var questions = BusinessUnity.QuestionService.GetQuestionsByTopic(topic, pageIndex, pageSize);

            return questions;
        }

        [Route("bytopic/{pageIndex:int}/{pageSize:int}/{topicName:alpha}")]
        public IEnumerable<QuestionDTO> GetQuestionsByTopicName(string topicName, int pageIndex, int pageSize = 10)
        {
            var questions = BusinessUnity.QuestionService.GetQuestionsByTopicName(topicName, pageIndex, pageSize);

            return questions;
        }

        [Route("questionhint/{id:int}")]
        public string GetQuestionHint(int id)
        {
            var hint = BusinessUnity.QuestionService.GetQuestionHint(id);

            return hint;
        }

        [Route("questionanswers/{id:int}")]
        public IEnumerable<AnswerDTO> GetQuestionAnswers(int id)
        {
            var answers = BusinessUnity.QuestionService.GetQuestionAnswers(id);

            return answers;
        }

        [Route("questioncorrectanswers/{id:int}")]
        public IEnumerable<AnswerDTO> GetCorrectQuestionAnswers(int id)
        {
            var answers = BusinessUnity.QuestionService.GetCorrectQuestionAnswers(id);

            return answers;
        }

        [Route("questionquizes/{id:int}")]
        public IEnumerable<QuizDTO> GetQuestionQuizez(int id)
        {
            var quizes = BusinessUnity.QuestionService.GetQuestionQuizez(id);

            return quizes;
        }

        [Route("questiontopic/{id:int}")]
        public TopicDTO GetQuestionTopic(int id)
        {
            var topic = BusinessUnity.QuestionService.GetQuestionTopic(id);

            return topic;
        }

        [HttpPatch]
        [Route("edit/{quesId:int}")]
        public bool ChangeQuestionAnswers([FromUri]int quesId, [FromBody] ICollection<AnswerDTO> answers)
        {
            return BusinessUnity.QuestionService.ChangeCorrectAnswers(quesId, answers);
        }

        [HttpPut]
        [Route("edit")]
        public bool EditQuestion([FromBody]QuestionDTO question)
        {
            return BusinessUnity.QuestionService.EditQuestion(question);
        }

        [HttpGet]
        [Route("usedStatus/{id:int}")]
        public bool CheckIsQuestionUsed(int id)
        {
            return BusinessUnity.QuestionService.IsQuestionUsed(id);
        }

        [HttpGet]
        [Route("activeStatus/{id:int}")]
        public bool CheckIsQuestionActive(int id)
        {
            return BusinessUnity.QuestionService.IsQuestionActive(id);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public bool RemoveQuestion(int id)
        {
            return BusinessUnity.QuestionService.Remove(id);
        }
    }
}