namespace Ogd.Virarium.Common.Layering.Persistence
{
    using Ogd.Virarium.Common.Layering.Business;

    public interface IRepositoryFactory
    {
        IRepository<T> GetRepository<T>()
            where T : class, IIdentifiable;
    }
}
