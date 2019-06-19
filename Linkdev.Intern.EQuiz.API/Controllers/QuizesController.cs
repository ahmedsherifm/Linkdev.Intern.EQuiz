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

        // GET: api/Quizes
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Quizes/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Quizes
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Quizes/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Quizes/5
        public void Delete(int id)
        {
        }
    }
}
