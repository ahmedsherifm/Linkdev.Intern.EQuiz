using Linkdev.Intern.EQuiz.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linkdev.Intern.EQuiz.Repo.Interfaces
{
    public interface ITopicRepository
    {
        IEnumerable<Topic> GetTopicsByCreationDate();

        IEnumerable<Topic> GetTopicsByName(bool ascending);

        IEnumerable<Topic> FilterTopicsByName(string name);

        IEnumerable<Topic> GetTopicsByPage(int pageIndex, int pageSize = 10);
    }
}
