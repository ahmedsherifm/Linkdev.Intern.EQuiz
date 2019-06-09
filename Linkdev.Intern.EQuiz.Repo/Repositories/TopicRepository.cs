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

        public IEnumerable<Topic> FilterTopicsByName(string name, int pageIndex, int pageSize = 10)
        {
            return EQuizContext.Topics
                    .Where(t => t.Name.ToLower()
                    .Contains(name.ToLower()))
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .AsEnumerable();
        }

        public IEnumerable<Topic> GetTopicsByCreationDate(int pageIndex, int pageSize = 10)
        {
            return EQuizContext.Topics
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .OrderByDescending(t => t.CreationDate)
                    .AsEnumerable();
        }

        public IEnumerable<Topic> GetTopicsByName(bool ascending, int pageIndex, int pageSize = 10)
        {
            if (ascending)
            { 
                return EQuizContext.Topics
                        .Skip((pageIndex - 1) * pageSize)
                        .Take(pageSize)
                        .OrderBy(t => t.Name);
            }
            else
            {
                return EQuizContext.Topics
                        .Skip((pageIndex - 1) * pageSize)
                        .Take(pageSize)
                        .OrderByDescending(t => t.Name);
            }
        }

        public IEnumerable<Topic> GetTopics(int pageIndex, int pageSize = 10)
        {
            return EQuizContext.Topics
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .AsEnumerable();
        }
    }
}