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
        private readonly ITopicService _topicService;

        public TopicsController(ITopicService topicService)
        {
            _topicService = topicService;
        }

        public TopicsController()
        {
            _topicService = new TopicService();
        }

        [Route("")]
        // GET: api/topic
        public IEnumerable<Topic> GetAllTopics()
        {
            var topics = _topicService.GetAllTopics();
            return topics;
        }

        [Route("{pageIndex:int}/{pageSize:int}")]
        // GET: api/topic/2/10
        public IEnumerable<Topic> GetTopicsPaging(int pageIndex, int pageSize)
        {
            var topics = _topicService.GetTopicsByCreationDate(pageIndex, pageSize).ToList();
            return topics;
        }

        [Route("{pageIndex:int}/{pageSize:int}/{name}")]
        // GET: api/topic/2/10/topi
        public IEnumerable<Topic> FilterTopicsByName(string name, int pageIndex, int pageSize)
        {
            var topics = _topicService.FilterTopicsByName(name, pageIndex, pageSize).ToList();
            return topics;
        }

        [Route("{id:int}")]
        // GET: api/topic/5
        public Topic GetTopicByID(int id)
        {
            var topic = _topicService.GetTopicByID(id);
            return topic;
        }

        [Route("ByName/{pageIndex:int}/{pageSize:int}/{ascending:bool}")]
        // GET: api/topic/ByName/2/10/1
        public IEnumerable<Topic> GetTopicsByName(bool ascending, int pageIndex, int pageSize)
        {
            var topics = _topicService.GetTopicsByName(ascending, pageIndex, pageSize).ToList();
            return topics;
        }

        [HttpPost]
        [Route("")]
        // POST: api/topic
        public bool? AddTopic([FromBody]Topic topic)
        {
            var isAdded = _topicService.AddTopic(topic);
            return isAdded;
        }

        [HttpPatch]
        [Route("ChangeName/{id:int}")]
        public bool? ChangeTopicName(int id,[FromBody] string name)
        {
            return _topicService.ChangeTopicName(id, name);
        }

        [HttpGet]
        [Route("Questions/{id:int}")]
        public IEnumerable<Question> GetTopicQuestions(int id)
        {
            return _topicService.GetTopicQuestions(id).ToList();
        }

        [HttpGet]
        [Route("CheckTopicStatus/{id:int}")]
        public Output CheckTopicStatus(int id)
        {
            return _topicService.CheckTopicStatus(id);
        }

        [HttpDelete]
        // I didn't set a riute as there is only one http delete method
        [Route("{id:int}")]
        public bool? RemoveTopic(int id)
        {
            return _topicService.RemoveTopic(id);
        }
    }
}