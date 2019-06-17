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
        // implementing generic repo services
        IEnumerable<Topic> GetAllTopics();

        Topic GetTopicByID(int id);

        bool? AddTopic(Topic entity);

        bool? RemoveTopic(Topic entity);

        IEnumerable<Topic> FindTopic(Expression<Func<Topic, bool>> predict);

        Topic GetTopicSingleOrDefault(Expression<Func<Topic, bool>> predict);

        // implemeting topic repo services
        IEnumerable<Topic> GetTopicsByCreationDate(int pageIndex, int pageSize = 10);

        IEnumerable<Topic> GetTopicsByName(bool ascending, int pageIndex, int pageSize = 10);

        IEnumerable<Topic> FilterTopicsByName(string name, int pageIndex, int pageSize = 10);
    }
}
