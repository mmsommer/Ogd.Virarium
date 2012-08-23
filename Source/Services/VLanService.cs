namespace Ogd.Virarium.Services
{
    using Ogd.Virarium.Common.Layering.Persistence;
    using Ogd.Virarium.Common.Layering.Service;
    using Ogd.Virarium.Data;
    using Ogd.Virarium.Domain.Models;

    public interface IVLanService : IService<VLan> { }

    public class VLanService : ServiceBase<VLan>, IVLanService
    {
        public VLanService() : this(default(IRepositoryFactory)) { }

        public VLanService(IRepositoryFactory repositoryFactory)
        {
            RepositoryFactory = repositoryFactory ?? new RepositoryFactory();
        }
    }
}
