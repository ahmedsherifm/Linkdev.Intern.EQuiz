using Linkdev.Intern.EQuiz.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Linkdev.Intern.EQuiz.Data;

namespace Linkdev.Intern.EQuiz.Repo.Interfaces
{
    public interface IQuizRepository :  IRepository<Quiz>
    {
        IEnumerable<Quiz> GetQuizesByQuestion(int qid);
    }
}
