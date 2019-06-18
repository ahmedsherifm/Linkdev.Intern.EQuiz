using Linkdev.Intern.EQuiz.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Linkdev.Intern.EQuiz.Service.Interfaces
{
    public interface IQuestionService
    {
        bool? Add(Question question);

        IEnumerable<Question> GetAllQuestions();

        Question GetQuestionById(int id);

        IEnumerable<Question> FindQuestions(Expression<Func<Question, bool>> predicate);

        IEnumerable<Question> GetQuestionsByCreationDate(int pageIndex, int pageSize = 10);

        IEnumerable<Question> GetQuestionsByName(bool ascending, int pageIndex, int pageSize = 10);

        IEnumerable<Question> FilterQuestionsByText(string text, int pageIndex, int pageSize = 10);

        IEnumerable<Question> GetQuestionsByTopic(Topic topic, int pageIndex, int pageSize = 10);

        IEnumerable<Question> GetQuestionsByTopicName(string topicName, int pageIndex, int pageSize = 10);

        string GetQuestionHint(int id);

        IEnumerable<Answer> GetQuestionAnswers(int id);

        IEnumerable<Quiz> GetQuestionQuizez(int id);

        Topic GetQuestionTopic(int id);
    }
}
