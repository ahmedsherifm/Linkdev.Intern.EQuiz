using Linkdev.Intern.EQuiz.Shared;
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
        // implementing generic repo services
        IEnumerable<TopicDTO> GetAllTopics();

        TopicDTO GetTopicByID(int id);

        bool? AddTopic(TopicDTO entity);

        //IEnumerable<Topic> FindTopic(Expression<Func<Topic, bool>> predict);

        //Topic GetTopicSingleOrDefault(Expression<Func<Topic, bool>> predict);

        // implemeting topic repo services
        IEnumerable<TopicDTO> GetTopicsByCreationDate(int pageIndex, int pageSize = 10);

        IEnumerable<TopicDTO> GetTopicsByName(bool ascending, int pageIndex, int pageSize = 10);

        IEnumerable<TopicDTO> FilterTopicsByName(string name, int pageIndex, int pageSize = 10);

        bool? RemoveTopic(int id);

        Output CheckTopicStatus(int id);

        IEnumerable<QuestionDTO> GetTopicQuestions(int id);

        bool? ChangeTopicName(int id, string name);

    }
}
