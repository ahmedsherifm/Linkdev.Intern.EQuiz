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
    public class TopicController : ApiController
    {
        private readonly ITopicService _topicService;

        public TopicController(ITopicService topicService)
        {
            _topicService = topicService;
        }

        // GET: api/Topic
        public IHttpActionResult GetAll()
        {
            var topics = _topicService.GetAllTopics();
            return Ok(topics);
        }

        // GET: api/Topic/5
        public IHttpActionResult Get(int id)
        {
            var topic = _topicService.GetTopicByID(id);
            if (topic != null)
                return Ok(topic);
            else
                return NotFound();
        }

        // POST: api/Topic
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
