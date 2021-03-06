﻿using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("Ogd.Virarium.Tests.Data")]
namespace Ogd.Virarium.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NHibernate;
    using NHibernate.Linq;
    using Ogd.Virarium.Common.Layering.Business;
    using Ogd.Virarium.Common.Layering.Persistence;

    public class Repository<T> : IRepository<T>
         where T : class, IIdentifiable
    {
        private ISessionFactory SessionFactory
        {
            get
            {
                if(NHibernateHelper != null)
                {
                    return NHibernateHelper.SessionFactory;
                }
                else
                {
                    return null;
                }
            }
        }

        private INHibernateHelper NHibernateHelper { get; set; }

        private IQueryable<T> Collection { get; set; }

        internal Repository() : this(default(IQueryable<T>), default(INHibernateHelper)) { }

        internal Repository(
            IQueryable<T> initialCollection,
            INHibernateHelper nHibernateHelper
        )
        {
            NHibernateHelper = nHibernateHelper ?? new NHibernateHelper();
            Collection = initialCollection ?? SessionFactory.GetCurrentSession().Query<T>();
        }

        public virtual IQueryable<T> GetAll()
        {
            return Collection;
        }

        public virtual T GetById(int id)
        {
            return GetAll().SingleOrDefault(t => t.Id == id);
        }

        public virtual T Save(T entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            var session = SessionFactory.GetCurrentSession();

            entity.Id = (int)session.Save(entity);

            return entity;
        }

        public virtual bool Update(T entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            var session = SessionFactory.GetCurrentSession();

            session.Update(entity);

            return true;
        }

        public virtual bool Delete(T entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            var session = SessionFactory.GetCurrentSession();

            session.Delete(entity);

            return true;
        }

        public virtual bool SaveOrUpdateAll(IEnumerable<T> entities)
        {
            if(entities == null)
            {
                throw new ArgumentNullException("entity");
            }
            var returnValue = true;

            foreach(var entity in entities)
            {
                if(entity.Id < 1)
                {
                    returnValue &= this.Save(entity).Id > 0;
                }
                else
                {
                    returnValue &= this.Update(entity);
                }
            }

            return returnValue;
        }

        public virtual bool DeleteAll(IEnumerable<T> entities)
        {
            if(entities == null)
            {
                throw new ArgumentNullException("entity");
            }
            var returnValue = true;

            foreach(var entity in entities)
            {
                returnValue &= this.Delete(entity);
            }

            return returnValue;
        }
    }
}
