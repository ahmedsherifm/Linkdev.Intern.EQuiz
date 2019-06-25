using Linkdev.Intern.EQuiz.Shared;
using Linkdev.Intern.EQuiz.Service.BusinessUnity;
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
        
        [Route("")]
        // GET: api/topic
        public IEnumerable<TopicDTO> GetAllTopics()
        {
            var topics = BusinessUnity.TopicService.GetAllTopics();
            return topics;
        }

        [Route("{pageIndex:int}/{pageSize:int}")]
        // GET: api/topic/2/10
        public IEnumerable<TopicDTO> GetTopicsPaging(int pageIndex, int pageSize)
        {
            var topics = BusinessUnity.TopicService.GetTopicsByCreationDate(pageIndex, pageSize).ToList();
            return topics;
        }

        [Route("{pageIndex:int}/{pageSize:int}/{name}")]
        // GET: api/topic/2/10/topi
        public IEnumerable<TopicDTO> FilterTopicsByName(string name, int pageIndex, int pageSize)
        {
            var topics = BusinessUnity.TopicService.FilterTopicsByName(name, pageIndex, pageSize).ToList();
            return topics;
        }

        [Route("{id:int}")]
        // GET: api/topic/5
        public TopicDTO GetTopicByID(int id)
        {
            var topic = BusinessUnity.TopicService.GetTopicByID(id);
            return topic;
        }

        [Route("ByName/{pageIndex:int}/{pageSize:int}/{ascending:bool}")]
        // GET: api/topic/ByName/2/10/1
        public IEnumerable<TopicDTO> GetTopicsByName(bool ascending, int pageIndex, int pageSize)
        {
            var topics = BusinessUnity.TopicService.GetTopicsByName(ascending, pageIndex, pageSize).ToList();
            return topics;
        }

        [HttpPost]
        [Route("")]
        // POST: api/topic
        public bool? AddTopic([FromBody]TopicDTO topic)
        {
            var isAdded = BusinessUnity.TopicService.AddTopic(topic);
            return isAdded;
        }

        [HttpPatch]
        [Route("ChangeName/{id:int}")]
        public bool? ChangeTopicName(int id,[FromBody] string name)
        {
            return BusinessUnity.TopicService.ChangeTopicName(id, name);
        }

        [HttpGet]
        [Route("Questions/{id:int}")]
        public IEnumerable<QuestionDTO> GetTopicQuestions(int id)
        {
            return BusinessUnity.TopicService.GetTopicQuestions(id).ToList();
        }

        [HttpGet]
        [Route("CheckTopicStatus/{id:int}")]
        public Output CheckTopicStatus(int id)
        {
            return BusinessUnity.TopicService.CheckTopicStatus(id);
        }

        [HttpDelete]
        // I didn't set a riute as there is only one http delete method
        [Route("{id:int}")]
        public bool? RemoveTopic(int id)
        {
            return BusinessUnity.TopicService.RemoveTopic(id);
        }
    }
}