using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("Ogd.Virarium.Tests.Data")]
namespace Ogd.Virarium.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Ogd.Virarium.Common.Layering.Business;
    using Ogd.Virarium.Common.Layering.Persistence;

    public class RepositoryFactory : IRepositoryFactory
    {
        internal IRepositoryFactory Factory { get; private set; }

        private IDictionary<Type, object> DaoCache { get; set; }

        public RepositoryFactory() : this(default(IRepositoryFactory), default(IQueryable), default(INHibernateHelper)) { }

        internal RepositoryFactory(
            IRepositoryFactory wrappedFactory,
            IQueryable initialCollection,
            INHibernateHelper nHibernateHelper
        )
        {
            Factory = wrappedFactory ?? new GenericRepositoryFactory(initialCollection, nHibernateHelper);
            DaoCache = new Dictionary<Type, object>();
        }

        public IRepository<T> GetRepository<T>()
            where T : class, IIdentifiable
        {
            if(!DaoCache.ContainsKey(typeof(T)))
            {
                DaoCache.Add(typeof(T), Factory.GetRepository<T>());
            }
            return (IRepository<T>)DaoCache[typeof(T)];
        }
    }
}
