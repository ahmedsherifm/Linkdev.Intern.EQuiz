using Linkdev.Intern.EQuiz.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linkdev.Intern.EQuiz.Repo.Interfaces
{
    public interface IQuizRepository :  IRepository<Quiz>
    {
        IEnumerable<Quiz> GetQuizesByQuestion(int qid);

        // quiz answer ? wlla template answer ?
        IEnumerable<Answer> GetQuizAnswers(int id);

        bool? ExtendExpirationDate(int id, DateTime expirationDate);

        bool? DeactivateQuiz(int id);

        bool? DeactivateQuizesList(ICollection<int> quizesIds);

        bool? ActivateQuiz(int id);

        bool? UpdateNumberOfTrials(int id, int numberOfTrials);

        bool? UpdatePassingScore(int id, int passingScore);

        bool? ChangeQuizName(int id, string name);

        bool? IsQuizActive(int id);

        bool? RemoveSelectedDeactivatedQuizesList(ICollection<int> quizesIds);
    }
}
