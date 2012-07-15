using System.Linq;
using System.Runtime.CompilerServices;
using Ogd.Virarium.Common.Layering.Business;
using Ogd.Virarium.Common.Layering.Persistence;

[assembly: InternalsVisibleTo("Ogd.Virarium.Data.Tests")]
namespace Ogd.Virarium.Data
{
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
