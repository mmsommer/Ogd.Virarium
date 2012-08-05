namespace Ogd.Virarium.Web.Controllers
{
    using System.Web.Mvc;
    using Ogd.Virarium.Common.Layering.Presentation;
    using Ogd.Virarium.Domain.Models;
    using Ogd.Virarium.Services;
    using Ogd.Virarium.Web.Models;
    using Ogd.Virarium.Web.Models.Home;

    public class HomeController : BaseController
    {
        public IMachineService MachineService { get; private set; }

        public HomeController() : this(default(IMachineService)) { }

        public HomeController(IMachineService machineService)
        {
            MachineService = machineService ?? new MachineService();
        }

        public ActionResult Index()
        {
            var viewModel = new IndexViewModel();
            viewModel.Machines = Map<Machine, MachineViewModel>(MachineService.GetAll());

            return View(viewModel);
        }
    }
}
