using System;
using System.Linq;
using System.Linq.Expressions;
using Ogd.Virarium.Common.Layering.Business;
using Ogd.Virarium.Common.Layering.Persistence;

namespace Ogd.Virarium.Common.Layering.Service
{
    public abstract class ServiceBase<TEntity> : IService<TEntity>
        where TEntity : class, IIdentifiable
    {
        public virtual IRepositoryFactory RepositoryFactory { get; protected set; }

        public virtual IQueryable<TEntity> GetAll()
        {
            return RepositoryFactory.GetRepository<TEntity>().GetAll();
        }

        public virtual TEntity Find(int id)
        {
            return RepositoryFactory.GetRepository<TEntity>().GetById(id);
        }

        public virtual bool Exists(params Expression<Func<TEntity, bool>>[] selectors)
        {
            var exists = false;
            foreach (var selector in selectors)
            {
                exists &= GetAll().All(selector);
            }
            return exists;
        }

        public virtual void Create(TEntity entity)
        {
            RepositoryFactory.GetRepository<TEntity>().Save(entity);
        }

        public virtual void Update(TEntity entity)
        {
            RepositoryFactory.GetRepository<TEntity>().Update(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            RepositoryFactory.GetRepository<TEntity>().Delete(entity);
        }
    }

    public interface IService<T>
        where T : class, IIdentifiable
    {
        IQueryable<T> GetAll();

        T Find(int id);

        bool Exists(params Expression<Func<T, bool>>[] selectors);

        void Create(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
