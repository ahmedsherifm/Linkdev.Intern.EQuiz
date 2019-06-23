using Linkdev.Intern.EQuiz.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linkdev.Intern.EQuiz.Service.Interfaces
{
    public interface IQuizService
    {
        //bool? CreateQuizWithQuestions(Quiz quiz, IEnumerable<int> questionsIds);
        IEnumerable<Quiz> GetQuizesByQuestionID(int qid);

        Quiz GetQuizByID(int id);

        // quiz answer ? wlla template answer ?
        IEnumerable<Answer> GetQuizAnswers(int id);

        bool ExtendExpirationDate(int id, DateTime expirationDate);

        bool DeactivateQuiz(int id);

        bool DeactivateQuizesList(ICollection<int> quizesIds);

        bool ActivateQuiz(int id);

        bool UpdateNumberOfTrials(int id, int numberOfTrials);

        bool UpdatePassingScore(int id, int passingScore);

        bool ChangeQuizName(int id, string name);

        bool IsQuizActive(int id);

        bool RemoveSelectedDeactivatedQuizesList(ICollection<int> quizesIds);

        bool? CreateQuiz(Quiz quiz);

        bool? AddQuestionsToQuiz(int quizId, IEnumerable<int> questionsIds);
    }
}
