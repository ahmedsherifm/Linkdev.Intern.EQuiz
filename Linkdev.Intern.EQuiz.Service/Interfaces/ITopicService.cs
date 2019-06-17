using Linkdev.Intern.EQuiz.Mappers;
using Linkdev.Intern.EQuiz.Service.Utility;
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

        IEnumerable<Topic> FindTopic(Expression<Func<Topic, bool>> predict);

        Topic GetTopicSingleOrDefault(Expression<Func<Topic, bool>> predict);

        bool? RemoveTopic(int id);

        Output CheckTopicStatus(int id);

        IEnumerable<Question> GetTopicQuestions(int id);

        bool? ChangeTopicName(int id, string name);

    }
}
