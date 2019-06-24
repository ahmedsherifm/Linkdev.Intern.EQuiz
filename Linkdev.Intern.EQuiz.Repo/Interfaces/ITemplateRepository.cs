using Linkdev.Intern.EQuiz.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linkdev.Intern.EQuiz.Repo.Interfaces
{
    public interface ITemplateRepository : IRepository<Template>
    {
        IEnumerable<Template> GetTemplatesByQuestionId(int qid);

        IEnumerable<Template> GetTemplatesByEmployeeId(int employeeId);

        IEnumerable<Template> GetTemplatesByEmployeeAndQuizIds(int quizId, int employeeId);
    }
}
