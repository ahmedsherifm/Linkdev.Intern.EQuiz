using Linkdev.Intern.EQuiz.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linkdev.Intern.EQuiz.Repo.Interfaces
{
    public interface IQuestionRepository
    {
        bool? IsQuestionActive(int id);

        bool? IsQuestionUsed(int id);

        bool? EditQuestion(Question question);

        bool? ChangeCorrectAnswers(int questionId, ICollection<Answer> answers);
    }
}
