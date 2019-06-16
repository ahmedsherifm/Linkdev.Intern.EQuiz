using Linkdev.Intern.EQuiz.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Linkdev.Intern.EQuiz.Service.Interfaces
{
    public interface ITopicService
    {
        IEnumerable<Topic> GetAll();

        Topic GetByID(int id);

        bool? Add(Topic entity);

        bool? Remove(Topic entity);

        IEnumerable<Topic> Find(Expression<Func<Topic, bool>> predict);

        Topic SingleOrDefault(Expression<Func<Topic, bool>> predict);
    }
}
