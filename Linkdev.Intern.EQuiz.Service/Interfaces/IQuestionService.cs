using Linkdev.Intern.EQuiz.Mappers;
using Linkdev.Intern.EQuiz.Service.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linkdev.Intern.EQuiz.Service.Interfaces
{
    public interface IQuestionService
    {
        Question GetQuestionByID(int id);

        bool? IsQuestionActive(int id);

        bool? IsQuestionUsed(int id);

        bool? EditQuestion(Question question);

        bool? ChangeCorrectAnswers(int questionId, ICollection<Answer> answers);

        bool? Remove(int id);
    }
}
