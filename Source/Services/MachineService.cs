namespace Ogd.Virarium.Services
{
    using Ogd.Virarium.Common.Layering.Persistence;
    using Ogd.Virarium.Common.Layering.Service;
    using Ogd.Virarium.Data;
    using Ogd.Virarium.Domain.Models;

    public class MachineService : ServiceBase<Machine>
    {
        public MachineService() : this(default(IRepositoryFactory)) { }

        public MachineService(IRepositoryFactory repositoryFactory)
        {
            RepositoryFactory = repositoryFactory ?? new RepositoryFactory();
        }
    }
}
