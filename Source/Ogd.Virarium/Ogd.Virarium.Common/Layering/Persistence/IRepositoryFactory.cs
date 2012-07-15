using Ogd.Virarium.Common.Layering.Business;

namespace Ogd.Virarium.Common.Layering.Persistence
{
    public interface IRepositoryFactory
    {
        IRepository<T> GetRepository<T>()
            where T : class, IIdentifiable;
    }
}
