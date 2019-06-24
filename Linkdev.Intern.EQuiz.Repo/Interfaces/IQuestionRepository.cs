using Linkdev.Intern.EQuiz.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Linkdev.Intern.EQuiz.Data.Domain;

namespace Linkdev.Intern.EQuiz.Data.Repository.Interfaces
{
    public interface IQuestionRepository : IRepository<Question>
    {
        bool? IsQuestionActive(int id);

        bool? IsQuestionUsed(int id);

        bool? EditQuestion(Question question);

        bool? ChangeCorrectAnswers(int questionId, ICollection<Answer> answers);
        IEnumerable<Question> GetQuestionsByCreationDate(int pageIndex, int pageSize = 10);

        IEnumerable<Question> GetQuestionsByName(bool ascending, int pageIndex, int pageSize = 10);

        IEnumerable<Question> FilterQuestionsByText(string text, int pageIndex, int pageSize = 10);

        IEnumerable<Question> GetQuestionsByTopic(Topic topic, int pageIndex, int pageSize = 10);

        IEnumerable<Question> GetQuestionsByTopicName(string topicName, int pageIndex, int pageSize = 10);

        string GetQuestionHint(int id);


    }
}
