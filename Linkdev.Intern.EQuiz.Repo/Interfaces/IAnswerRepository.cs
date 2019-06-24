using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Linkdev.Intern.EQuiz.Data.Domain;

namespace Linkdev.Intern.EQuiz.Data.Repository.Interfaces
{
    public interface IAnswerRepository : IRepository<Answer>
    {
        // For Listing Question details requirement
        IEnumerable<Answer> GetAnswersByQuestion(int qid);

        IEnumerable<Answer> GetCorrectAnswersByQuestion(int qid);
    }
}
