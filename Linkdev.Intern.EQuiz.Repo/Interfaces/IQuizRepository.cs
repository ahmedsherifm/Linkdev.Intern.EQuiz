using Linkdev.Intern.EQuiz.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linkdev.Intern.EQuiz.Data.Repository.Interfaces
{
    public interface IQuizRepository :  IRepository<Quize>
    {
        IEnumerable<Quize> GetQuizesByQuestion(int qid);

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

        IEnumerable<Quize> GetQuizesByCreationDate(int pageIndex, int pageSize = 10);

        IEnumerable<Quize> GetQuizesByName(bool ascending, int pageIndex, int pageSize = 10);

        IEnumerable<Quize> FilterQuizesByName(string name, int pageIndex, int pageSize = 10);

        IEnumerable<Quize> GetActiveQuizes(int pageIndex, int pageSize = 10);

        IEnumerable<Quize> FilterQuizesByQuarter(int quarter, int pageIndex, int pageSize = 10);

        IEnumerable<Quize> FilterQuizesByYear(int year, int pageIndex, int pageSize = 10);

        int GetTrialsNoForEmployee(int quizId, int employeeId);
    }
}
