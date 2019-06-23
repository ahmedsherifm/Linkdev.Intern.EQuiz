using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Linkdev.Intern.EQuiz.Data;

namespace Linkdev.Intern.EQuiz.Repo.Interfaces
{
    public interface IQuestionQuizRepository: IRepository<Questions_Quizes>
    {
        bool? Add(IEnumerable<Question> questions, Quize quiz);

        IEnumerable<Question> GetQuizQuestions(Quize quiz);

        IEnumerable<Question> GetQuizQuestionsByQuizID(int quizID);
    }
}
