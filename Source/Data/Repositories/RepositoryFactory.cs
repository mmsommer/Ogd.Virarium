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

        private IDictionary<Type, object> _cache { get; set; }

        public RepositoryFactory() : this(default(IRepositoryFactory), default(IQueryable), default(INHibernateHelper)) { }

        internal RepositoryFactory(
            IRepositoryFactory wrappedFactory,
            IQueryable initialCollection,
            INHibernateHelper nHibernateHelper
        )
        {
            Factory = wrappedFactory ?? new GenericRepositoryFactory(initialCollection, nHibernateHelper);
            _cache = new Dictionary<Type, object>();
        }

        public IRepository<T> GetRepository<T>()
            where T : class, IIdentifiable
        {
            if(!_cache.ContainsKey(typeof(T)))
            {
                _cache.Add(typeof(T), Factory.GetRepository<T>());
            }
            return (IRepository<T>)_cache[typeof(T)];
        }
    }
}
