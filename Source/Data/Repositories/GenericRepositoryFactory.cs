using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("Ogd.Virarium.Tests.Data")]
namespace Ogd.Virarium.Data
{
    using System.Linq;
    using Ogd.Virarium.Common.Layering.Business;
    using Ogd.Virarium.Common.Layering.Persistence;

    internal class GenericRepositoryFactory : IRepositoryFactory
    {
        private IQueryable InitialCollection { get; set; }

        private INHibernateHelper NHibernateHelper { get; set; }

        public GenericRepositoryFactory() : this(default(IQueryable), default(INHibernateHelper)) { }

        public GenericRepositoryFactory(
            IQueryable initialCollection,
            INHibernateHelper nHibernateHelper
        )
        {
            InitialCollection = initialCollection;
            NHibernateHelper = nHibernateHelper ?? new NHibernateHelper();
        }

        public IRepository<T> GetRepository<T>()
            where T : class, IIdentifiable
        {
            return new Repository<T>((IQueryable<T>)InitialCollection, NHibernateHelper);
        }
    }
}
