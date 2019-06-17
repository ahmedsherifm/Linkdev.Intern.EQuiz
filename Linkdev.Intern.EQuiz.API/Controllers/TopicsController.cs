using Linkdev.Intern.EQuiz.Mappers;
using Linkdev.Intern.EQuiz.Service.Interfaces;
using Linkdev.Intern.EQuiz.Service.Services;
using Linkdev.Intern.EQuiz.Service.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Linkdev.Intern.EQuiz.API.Controllers
{
    [RoutePrefix("api/topics")]
    public class TopicsController : ApiController
    {
        private readonly ITopicService topicService;
        public TopicsController()
        {
            topicService = new TopicService();
        }

        [HttpPatch]
        [Route("ChangeName/{id:int}")]
        public bool? ChangeTopicName(int id,[FromBody] string name)
        {
            return topicService.ChangeTopicName(id, name);
        }

        [HttpGet]
        [Route("Questions/{id:int}")]
        public IEnumerable<Question> GetTopicQuestions(int id)
        {
            return topicService.GetTopicQuestions(id).ToList();
        }

        [HttpGet]
        [Route("CheckTopicStatus/{id:int}")]
        public Output CheckTopicStatus(int id)
        {
            return topicService.CheckTopicStatus(id);
        }

        [HttpDelete]
        // I didn't set a riute as there is only one http delete method
        [Route("{id:int}")]
        public bool? RemoveTopic(int id)
        {
            return topicService.RemoveTopic(id);
        }
    }
}
