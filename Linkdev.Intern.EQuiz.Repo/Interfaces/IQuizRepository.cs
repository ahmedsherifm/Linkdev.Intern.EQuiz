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

        bool? AssignEmployeesToQuiz(int id, ICollection<Employee> employees);

        bool? ReleaseQuizFromEmployees(int id, ICollection<Employee> employees);

        bool? AssignEmployeesToReTakeQuiz(int id, ICollection<Employee> employees);

        bool? ExtendExpirationDate(int id, DateTime expirationDate);
    }
}
