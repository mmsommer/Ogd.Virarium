namespace Ogd.Virarium.Services
{
    using System.Linq;
    using Ogd.Virarium.Common.Layering.Persistence;
    using Ogd.Virarium.Common.Layering.Service;
    using Ogd.Virarium.Data;
    using Ogd.Virarium.Domain.Models;

    public interface IMachineService : IService<Machine> { }

    public class MachineService : ServiceBase<Machine>, IMachineService
    {
        public MachineService() : this(default(IRepositoryFactory)) { }

        public MachineService(IRepositoryFactory repositoryFactory)
        {
            RepositoryFactory = repositoryFactory ?? new RepositoryFactory();
        }

        public override IQueryable<Machine> GetAll()
        {
            return base.GetAll().Where(x => !x.Archived);
        }
    }
}
