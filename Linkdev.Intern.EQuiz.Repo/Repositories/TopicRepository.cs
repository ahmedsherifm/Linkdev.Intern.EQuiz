using Linkdev.Intern.EQuiz.Data;
using Linkdev.Intern.EQuiz.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Linkdev.Intern.EQuiz.Repo.Repositories
{
    public class TopicRepository : Repository<Topic>, ITopicRepository
    {
        public TopicRepository(EQuizContext context) : base(context)
        {
        }
    }
}