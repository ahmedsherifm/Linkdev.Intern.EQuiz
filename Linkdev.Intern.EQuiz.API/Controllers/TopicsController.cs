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
    [RoutePrefix("api/topics")]
    public class TopicsController : ApiController
    {
        private readonly ITopicService _topicService;

        public TopicsController(ITopicService topicService)
        {
            _topicService = new TopicService();
            //_topicService = topicService;
        }

        [Route("")]
        // GET: api/Topic
        public IEnumerable<Topic> GetAllTopics()
        {
            var topics = _topicService.GetAllTopics();
            return topics;
        }

        [Route("{pageIndex:int}/{pageSize:int}")]
        // GET: api/Topic/2/10
        public IEnumerable<Topic> GetTopicsPaging(int pageIndex,int pageSize)
        {
            var topics = _topicService.GetTopicsByCreationDate(pageIndex,pageSize);
            return topics;
        }

        [Route("{id:int}")]
        // GET: api/Topic/5
        public Topic GetTopicByID(int id)
        {
            var topic = _topicService.GetTopicByID(id);
            return topic;
        }

        [Route("byname/{pageIndex:int}/{pageSize:int}/{ascending:bool}")]
        // GET: api/Topic/2/10
        public IEnumerable<Topic> GetTopicsByName(bool ascending, int pageIndex, int pageSize)
        {
            var topics = _topicService.GetTopicsByName(ascending,pageIndex, pageSize);
            return topics;
        }

        [Route("{pageIndex:int}/{pageSize:int}/{name}")]
        // GET: api/Topic/2/10
        public IEnumerable<Topic> FilterTopicsByName(string name, int pageIndex, int pageSize)
        {
            var topics = _topicService.FilterTopicsByName(name, pageIndex, pageSize);
            return topics;
        }

        //[HttpPost]
        //[Route("")]
        //// POST: api/Topic
        //public bool? AddTopic([FromBody]Topic topic)
        //{
        //    var isAdded = _topicService.AddTopic(topic);
        //    return isAdded;
        //}
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Topic/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Topic/5
        public void Delete(int id)
        {
        }
    }
}
