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
        public EQuizContext EQuizContext
        {
            get
            {
                return Context as EQuizContext;
            }
        }

        public TopicRepository(EQuizContext context) : base(context)
        {
        }

        public IEnumerable<Topic> FilterTopicsByName(string name)
        {
            return EQuizContext.Topics
                .Where(t => t.Name.ToLower()
                .Contains(name.ToLower()))
                .AsEnumerable();
        }

        public IEnumerable<Topic> GetTopicsByCreationDate()
        {
            return EQuizContext.Topics
                .OrderByDescending(t => t.CreationDate)
                .AsEnumerable();
        }

        public IEnumerable<Topic> GetTopicsByName(bool ascending)
        {
            if (ascending)
                return EQuizContext.Topics.OrderBy(t => t.Name);

            return EQuizContext.Topics.OrderByDescending(t => t.Name);
        }

        public IEnumerable<Topic> GetTopicsByPage(int pageIndex, int pageSize = 10)
        {
            return EQuizContext.Topics
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .AsEnumerable();
        }
    }
}