using Linkdev.Intern.EQuiz.Shared;
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
        bool? Add(QuestionDTO question);

        IEnumerable<QuestionDTO> GetAllQuestions();

        QuestionDTO GetQuestionById(int id);

        //IEnumerable<Question> FindQuestions(Expression<Func<Question, bool>> predicate);

        IEnumerable<QuestionDTO> GetQuestionsByCreationDate(int pageIndex, int pageSize = 10);

        IEnumerable<QuestionDTO> GetQuestionsByName(bool ascending, int pageIndex, int pageSize = 10);

        IEnumerable<QuestionDTO> FilterQuestionsByText(string text, int pageIndex, int pageSize = 10);

        IEnumerable<QuestionDTO> GetQuestionsByTopic(TopicDTO topic, int pageIndex, int pageSize = 10);

        IEnumerable<QuestionDTO> GetQuestionsByTopicName(string topicName, int pageIndex, int pageSize = 10);

        string GetQuestionHint(int id);

        IEnumerable<AnswerDTO> GetQuestionAnswers(int id);

        IEnumerable<AnswerDTO> GetCorrectQuestionAnswers(int id);

        IEnumerable<QuizDTO> GetQuestionQuizez(int id);

        TopicDTO GetQuestionTopic(int id);

        bool IsQuestionActive(int id);

        bool IsQuestionUsed(int id);

        bool EditQuestion(QuestionDTO question);

        bool ChangeCorrectAnswers(int questionId, ICollection<AnswerDTO> answers);

        bool Remove(int id);
    }
}