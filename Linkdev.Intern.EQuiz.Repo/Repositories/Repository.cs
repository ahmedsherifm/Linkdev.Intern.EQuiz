using Linkdev.Intern.EQuiz.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Linkdev.Intern.EQuiz.Repo.Repositories
{
    internal class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public EQuizContext Context { get; private set; }

        public Repository(EQuizContext context)
        {
            Context = context;
        }

        public bool? Add(TEntity entity)
        {
            if(entity != null)
            {
                Context.Set<TEntity>().Add(entity);
                return true;
            }

            return false;
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predict)
        {
            return Context.Set<TEntity>().Where(predict).AsEnumerable();
        }

        public IEnumerable<TEntity> GetAll()
        {
            //return Context.Set<TEntity>();
            return Context.Set<TEntity>().AsEnumerable();
        }

        public TEntity GetByID(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public bool? Remove(TEntity entity)
        {
            if(entity != null)
            {
                Context.Set<TEntity>().Remove(entity);
                return true;
            }

            return false;
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predict)
        {
            return Context.Set<TEntity>().SingleOrDefault(predict);
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
}