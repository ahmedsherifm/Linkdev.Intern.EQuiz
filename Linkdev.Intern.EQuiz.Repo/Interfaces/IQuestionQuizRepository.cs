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
        bool? Add(IEnumerable<Question> questions, Quiz quiz);

        IEnumerable<Question> GetQuizQuestions(Quiz quiz);

        IEnumerable<Question> GetQuizQuestionsByQuizID(int quizID);
    }
}
