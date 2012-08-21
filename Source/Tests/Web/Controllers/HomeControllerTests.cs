namespace Ogd.Virarium.Tests.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Moq;
    using NUnit.Framework;
    using Ogd.Virarium.Domain.Models;
    using Ogd.Virarium.Services;
    using Ogd.Virarium.Tests.Common.Presentation;
    using Ogd.Virarium.Web.Controllers;
    using Ogd.Virarium.Web.Models.Home;

    [TestFixture]
    public class HomeControllerTests : BaseControllerTests<HomeController>
    {
        Mock<IMachineService> machineService { get; set; }

        protected override HomeController CreateImplementation()
        {
            return new HomeController(machineService.Object);
        }

        [SetUp]
        public void Init()
        {
            machineService = new Mock<IMachineService>();
        }

        [Test]
        public void Constructor_NoMachineServiceGiven_MachineServiceSet()
        {
            // Assign
            // Act
            var sut = new HomeController();

            // Assert
            Assert.That(() => sut.MachineService, Is.InstanceOf<IMachineService>());
        }

        [Test]
        public void Constructor_MachineServiceGiven_MachineServiceIsSame()
        {
            // Assign
            var machineService = new Mock<IMachineService>();

            // Act
            var sut = new HomeController(machineService.Object);

            // Assert
            Assert.That(() => sut.MachineService, Is.SameAs(machineService.Object));
        }

        [Test]
        public void Index_ViewDataHasIndexViewModel()
        {
            // Assign
            var sut = CreateImplementation();

            // Act
            sut.Index();

            // Assert
            Assert.That(() => sut.ViewData.Model, Is.InstanceOf<IndexViewModel>());
        }

        [Test]
        public void Index_ReturnsViewResult()
        {
            // Assign
            var sut = CreateImplementation();

            // Act
            var result = sut.Index();

            // Assert
            Assert.That(() => result, Is.InstanceOf<ViewResult>());
        }

        [Test]
        public void Index_MachineServiceReturnsNoMachine_ViewModelHasNoMachine()
        {
            // Assign
            machineService
                .Setup(x => x.GetAll())
                .Returns(() => new List<Machine> { }.AsQueryable());
            var sut = CreateImplementation();

            // Act
            sut.Index();

            // Assert
            Assert.That(() => ((IndexViewModel)sut.ViewData.Model).Machines, Is.Empty);
        }

        [Test]
        public void Index_MachineServiceReturnsOneMachine_ViewModelHasOneMachine()
        {
            // Assign
            machineService
                .Setup(x => x.GetAll())
                .Returns(() => new List<Machine> { new Machine { Id = 1 } }.AsQueryable());
            var sut = CreateImplementation();

            // Act
            sut.Index();

            // Assert
            Assert.That(() => ((IndexViewModel)sut.ViewData.Model).Machines, Is.Not.Empty);
        }
    }
}
