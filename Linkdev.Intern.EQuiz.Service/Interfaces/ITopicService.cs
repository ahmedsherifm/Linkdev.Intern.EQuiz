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
        IEnumerable<Topic> GetAllTopics();

        Topic GetTopicByID(int id);

        bool? AddTopic(Topic entity);

        bool? RemoveTopic(Topic entity);

        IEnumerable<Topic> FindTopic(Expression<Func<Topic, bool>> predict);

        Topic GetTopicSingleOrDefault(Expression<Func<Topic, bool>> predict);
    }
}
