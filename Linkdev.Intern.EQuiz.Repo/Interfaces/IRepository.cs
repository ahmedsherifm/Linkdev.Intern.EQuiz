using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Linkdev.Intern.EQuiz.Repo.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();

        TEntity GetByID(int id);

        bool? Add(TEntity entity);

        bool? Remove(TEntity entity);

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predict);

        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predict);

    }
}
