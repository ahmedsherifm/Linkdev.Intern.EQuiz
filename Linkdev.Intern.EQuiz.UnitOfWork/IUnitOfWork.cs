using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Linkdev.Intern.EQuiz.Repo.Interfaces;

namespace Linkdev.Intern.EQuiz.UnitOfWork
{
    interface IUnitOfWork
    {
        
        void SaveChanges();
    }
}
