namespace Ogd.Virarium.Tests.Common.Presentation
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Moq;
    using NUnit.Framework;
    using Ogd.Virarium.Common.Layering.Business;
    using Ogd.Virarium.Common.Layering.Presentation;
    using Ogd.Virarium.Common.Layering.Service;

    [TestFixture]
    public abstract class BaseCrudControllerTests<TEntity, TViewModel> : BaseControllerTests<BaseCrudController<TEntity, TViewModel>>
        where TEntity : class, IIdentifiable, new()
        where TViewModel : class, IViewModel<TEntity>, new()
    {
        protected abstract BaseCrudController<TEntity, TViewModel> CreateImplementation(IService<TEntity> service);

        protected override BaseCrudController<TEntity, TViewModel> CreateImplementation()
        {
            return this.CreateImplementation(null);
        }

        [Test]
        public void GET_Index_ReturnsIIndexViewModelOfT()
        {
            // Assign
            var service = new Mock<IService<TEntity>>();
            var sut = CreateImplementation(service.Object);

            // Act
            sut.Index();

            // Assert
            Assert.That(() => sut.ViewData.Model, Is.InstanceOf<IEnumerable<TViewModel>>());
        }

        [Test]
        public void GET_Details_VerifyServiceFindIsCalled()
        {
            // Assign
            var service = new Mock<IService<TEntity>>();
            service
                .Setup(x => x.Find(It.IsAny<int>()))
                .Returns(new TEntity());
            var sut = CreateImplementation(service.Object);

            // Act
            sut.Details(1);

            // Assert
            service.Verify(x => x.Find(It.IsAny<int>()), Times.Once());
        }

        [Test]
        public void GET_Details_ReturnsIDetailsViewModelOfT()
        {
            // Assign
            var service = new Mock<IService<TEntity>>();
            service
                .Setup(x => x.Find(It.IsAny<int>()))
                .Returns(new TEntity());
            var sut = CreateImplementation(service.Object);

            // Act
            sut.Details(1);

            // Assign
            Assert.That(() => sut.ViewData.Model, Is.InstanceOf<TViewModel>());
        }

        [Test]
        public void GET_DetailsRow_VerifyServiceFindIsCalled()
        {
            // Assign
            var service = new Mock<IService<TEntity>>();
            service
                .Setup(x => x.Find(It.IsAny<int>()))
                .Returns(new TEntity());
            var sut = CreateImplementation(service.Object);

            // Act
            sut.DetailsRow(1);

            // Assert
            service.Verify(x => x.Find(It.IsAny<int>()), Times.Once());
        }

        [Test]
        public void GET_DetailsRow_ReturnsIDetailsViewModelOfT()
        {
            // Assign
            var service = new Mock<IService<TEntity>>();
            service
                .Setup(x => x.Find(It.IsAny<int>()))
                .Returns(new TEntity());
            var sut = CreateImplementation(service.Object);

            // Act
            sut.DetailsRow(1);

            // Assign
            Assert.That(() => sut.ViewData.Model, Is.InstanceOf<TViewModel>());
        }

        [Test]
        public void GET_Create_VerifyServiceFindIsNeverCalled()
        {
            // Assign
            var service = new Mock<IService<TEntity>>();
            service
                .Setup(x => x.Find(It.IsAny<int>()))
                .Returns(new TEntity());
            var sut = CreateImplementation(service.Object);

            // Act
            sut.Create();

            // Assert
            service.Verify(x => x.Find(It.IsAny<int>()), Times.Never());
        }

        [Test]
        public void GET_Create_ReturnsICreateViewModelOfT()
        {
            // Assign
            var service = new Mock<IService<TEntity>>();
            service
                .Setup(x => x.Find(It.IsAny<int>()))
                .Returns(new TEntity());
            var sut = CreateImplementation(service.Object);

            // Act
            sut.Create();

            // Assign
            Assert.That(() => sut.ViewData.Model, Is.InstanceOf<TViewModel>());
        }

        [Test]
        public void POST_Create_InvalidModelState_ReturnsViewModelOfT()
        {
            // Assign
            var service = new Mock<IService<TEntity>>();
            var viewModel = new Mock<TViewModel>();
            var sut = CreateImplementation(service.Object);
            sut.ModelState.AddModelError("error", "error");

            // Act
            sut.Create(viewModel.Object);

            // Assert
            Assert.That(() => sut.ViewData.Model, Is.InstanceOf<TViewModel>());
        }

        [Test]
        public void POST_Create_ValidModelState_VerifyServiceUpdateIsCalled()
        {
            // Assign
            var service = new Mock<IService<TEntity>>();
            var viewModel = new Mock<TViewModel>();
            var sut = CreateImplementation(service.Object);

            // Act
            sut.Create(viewModel.Object);

            // Assert
            service.Verify(x => x.Create(It.IsAny<TEntity>()), Times.Once());
        }

        [Test]
        public void POST_Create_ValidModelState_ReturnsRedirectRouteResult()
        {
            // Assign
            var service = new Mock<IService<TEntity>>();
            var viewModel = new Mock<TViewModel>();
            var sut = CreateImplementation(service.Object);

            // Act
            var result = sut.Create(viewModel.Object);

            // Assert
            Assert.That(() => result, Is.InstanceOf<RedirectToRouteResult>());
        }

        [Test]
        public void GET_Edit_VerifyServiceFindIsCalled()
        {
            // Assign
            var service = new Mock<IService<TEntity>>();
            service
                .Setup(x => x.Find(It.IsAny<int>()))
                .Returns(new TEntity());
            var sut = CreateImplementation(service.Object);

            // Act
            sut.Edit(1);

            // Assert
            service.Verify(x => x.Find(It.IsAny<int>()), Times.Once());
        }

        [Test]
        public void GET_Edit_ReturnsIEditViewModelOfT()
        {
            // Assign
            var service = new Mock<IService<TEntity>>();
            service
                .Setup(x => x.Find(It.IsAny<int>()))
                .Returns(new TEntity());
            var sut = CreateImplementation(service.Object);

            // Act
            sut.Edit(1);

            // Assert
            Assert.That(() => sut.ViewData.Model, Is.InstanceOf<TViewModel>());
        }

        [Test]
        public void POST_Edit_InvalidModelState_ReturnsViewModelOfT()
        {
            // Assign
            var service = new Mock<IService<TEntity>>();
            var viewModel = new Mock<TViewModel>();
            var sut = CreateImplementation(service.Object);
            sut.ModelState.AddModelError("error", "error");

            // Act
            sut.Edit(viewModel.Object);

            // Assert
            Assert.That(() => sut.ViewData.Model, Is.InstanceOf<TViewModel>());
        }

        [Test]
        public void POST_Edit_ValidModelState_VerifyServiceUpdateIsCalled()
        {
            // Assign
            var service = new Mock<IService<TEntity>>();
            var viewModel = new Mock<TViewModel>();
            var sut = CreateImplementation(service.Object);

            // Act
            sut.Edit(viewModel.Object);

            // Assert
            service.Verify(x => x.Update(It.IsAny<TEntity>()), Times.Once());
        }

        [Test]
        public void POST_Edit_ValidModelState_ReturnsRedirectRouteResult()
        {
            // Assign
            var service = new Mock<IService<TEntity>>();
            var viewModel = new Mock<TViewModel>();
            var sut = CreateImplementation(service.Object);

            // Act
            var result = sut.Edit(viewModel.Object);

            // Assert
            Assert.That(() => result, Is.InstanceOf<RedirectToRouteResult>());
        }

        [Test]
        public void GET_Delete_VerifyServiceFindIsCalled()
        {
            // Assign
            var service = new Mock<IService<TEntity>>();
            service
                .Setup(x => x.Find(It.IsAny<int>()))
                .Returns(new TEntity());
            var sut = CreateImplementation(service.Object);

            // Act
            sut.Delete(1);

            // Assert
            service.Verify(x => x.Find(It.IsAny<int>()), Times.Once());
        }

        [Test]
        public void GET_Delete_ReturnsIDeleteViewModelOfT()
        {
            // Assign
            var service = new Mock<IService<TEntity>>();
            service
                .Setup(x => x.Find(It.IsAny<int>()))
                .Returns(new TEntity());
            var sut = CreateImplementation(service.Object);

            // Act
            sut.Delete(1);

            // Assign
            Assert.That(() => sut.ViewData.Model, Is.InstanceOf<TViewModel>());
        }

        [Test]
        public void POST_Delete_InvalidModelState_ReturnsViewModelOfT()
        {
            // Assign
            var service = new Mock<IService<TEntity>>();
            var viewModel = new Mock<TViewModel>();
            var sut = CreateImplementation(service.Object);
            sut.ModelState.AddModelError("error", "error");

            // Act
            sut.Delete(viewModel.Object);

            // Assert
            Assert.That(() => sut.ViewData.Model, Is.InstanceOf<TViewModel>());
        }

        [Test]
        public void POST_Delete_ValidModelState_VerifyServiceUpdateIsCalled()
        {
            // Assign
            var service = new Mock<IService<TEntity>>();
            var viewModel = new Mock<TViewModel>();
            var sut = CreateImplementation(service.Object);

            // Act
            sut.Delete(viewModel.Object);

            // Assert
            service.Verify(x => x.Delete(It.IsAny<TEntity>()), Times.Once());
        }

        [Test]
        public void POST_Delete_ValidModelState_ReturnsRedirectRouteResult()
        {
            // Assign
            var service = new Mock<IService<TEntity>>();
            var viewModel = new Mock<TViewModel>();
            var sut = CreateImplementation(service.Object);

            // Act
            var result = sut.Delete(viewModel.Object);

            // Assert
            Assert.That(() => result, Is.InstanceOf<RedirectToRouteResult>());
        }

        [Test]
        public void GET_DetailsRow_ReturnsPartialViewModel()
        {
            // Assign
            var service = new Mock<IService<TEntity>>();
            var sut = CreateImplementation(service.Object);

            // Act
            var result = sut.DetailsRow();

            // Assert
            Assert.That(() => result, Is.InstanceOf<PartialViewResult>());
        }

        [Test]
        public void GET_DetailsRow_ReturnsViewModelOfT()
        {
            // Assign
            var service = new Mock<IService<TEntity>>();
            var sut = CreateImplementation(service.Object);

            // Act
            sut.DetailsRow();

            // Assert
            Assert.That(() => sut.ViewData.Model, Is.InstanceOf<IEnumerable<TViewModel>>());
        }

        [Test]
        public void GET_EditRow_ReturnsPartialViewModel()
        {
            // Assign
            var service = new Mock<IService<TEntity>>();
            var sut = CreateImplementation(service.Object);

            // Act
            var result = sut.EditRow();

            // Assert
            Assert.That(() => result, Is.InstanceOf<PartialViewResult>());
        }

        [Test]
        public void GET_EditRow_ReturnsViewModelOfT()
        {
            // Assign
            var service = new Mock<IService<TEntity>>();
            var sut = CreateImplementation(service.Object);

            // Act
            sut.EditRow();

            // Assert
            Assert.That(() => sut.ViewData.Model, Is.InstanceOf<IEnumerable<TViewModel>>());
        }
    }
}
