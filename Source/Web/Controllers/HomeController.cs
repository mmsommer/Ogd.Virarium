﻿namespace Ogd.Virarium.Web.Controllers
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

        public IVLanService VLanService { get; private set; }

        public HomeController() : this(default(IMachineService), default(IVLanService)) { }

        public HomeController(IVLanService vLanService) : this(default(IMachineService), vLanService) { }

        public HomeController(IMachineService machineService) : this(machineService, default(IVLanService)) { }

        public HomeController(IMachineService machineService, IVLanService vLanService)
        {
            MachineService = machineService ?? new MachineService();
            VLanService = vLanService ?? new VLanService();
        }

        [HttpGet]
        public ActionResult Index()
        {
            CreateMap<Connection, ConnectionViewModel>();
            CreateMap<Infection, InfectionViewModel>();
            CreateMap<Machine, MachineViewModel>();
            CreateMap<NIC, NICViewModel>();
            CreateMap<Virus, VirusViewModel>();
            CreateMap<VLan, VLanViewModel>();

            var viewModel = new IndexViewModel();
            viewModel.Machines = Map<Machine, MachineViewModel>(MachineService.GetAll());
            viewModel.VLans = Map<VLan, VLanViewModel>(VLanService.GetAll());

            return View(viewModel);
        }

        [HttpGet]
        public PartialViewResult UpdateVirarium()
        {
            CreateMap<Connection, ConnectionViewModel>();
            CreateMap<Infection, InfectionViewModel>();
            CreateMap<Machine, MachineViewModel>();
            CreateMap<NIC, NICViewModel>();
            CreateMap<Virus, VirusViewModel>();
            CreateMap<VLan, VLanViewModel>();

            var viewModel = new IndexViewModel();
            viewModel.Machines = Map<Machine, MachineViewModel>(MachineService.GetAll());
            viewModel.VLans = Map<VLan, VLanViewModel>(VLanService.GetAll());

            return PartialView("ViewObjects/Virarium", viewModel);
        }
    }
}
