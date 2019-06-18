using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Linkdev.Intern.EQuiz.Data;

namespace Linkdev.Intern.EQuiz.Repo.Interfaces
{
    public interface IAnswerRepository : IRepository<Answer>
    {
        // For Listing Question details requirement
        IEnumerable<Answer> GetAnswersByQuestion(int qid);
    }
}
