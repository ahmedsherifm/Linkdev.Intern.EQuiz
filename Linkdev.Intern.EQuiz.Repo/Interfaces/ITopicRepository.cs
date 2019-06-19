using Linkdev.Intern.EQuiz.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linkdev.Intern.EQuiz.Repo.Interfaces
{
    public interface ITopicRepository: IRepository<Topic>
    {
        IEnumerable<Topic> GetTopicsByCreationDate(int pageIndex, int pageSize = 10);

        IEnumerable<Topic> GetTopicsByName(bool ascending, int pageIndex, int pageSize = 10);

        IEnumerable<Topic> FilterTopicsByName(string name, int pageIndex, int pageSize = 10);

        IEnumerable<Question> GetTopicQuestions(int id);

        bool? TopicHasQuestion(int id);

        bool? TopicHasQuestionUsed(int id);

        bool? ChangeTopicName(int id, string name);

        // for Question Details Requirements
        Topic GetTopicByQuestion(int qid);
    }
}
