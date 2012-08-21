namespace Ogd.Virarium.Tests.Services
{
    using Moq;
    using NUnit.Framework;
    using Ogd.Virarium.Common.Layering.Persistence;
    using Ogd.Virarium.Common.Layering.Service;
    using Ogd.Virarium.Domain.Models;
    using Ogd.Virarium.Services;
    using Ogd.Virarium.Tests.Common.Layering.ServiceLayer;

    [TestFixture]
    public class MachineServiceTests : IServiceTests<Machine>
    {
        Mock<IRepositoryFactory> repositoryFactory { get; set; }

        protected override IService<Machine> CreateServiceImplementation(IRepositoryFactory repositoryFactory)
        {
            return new MachineService(repositoryFactory);
        }

        [SetUp]
        public void Init()
        {
            repositoryFactory = new Mock<IRepositoryFactory>();
        }

        [Test]
        public void Constructor_NoRepositoryFactoryGiven_RepositoryFactoryIsSet()
        {
            // Assign
            // Act
            var sut = new MachineService();

            // Assert
            Assert.That(() => sut.RepositoryFactory, Is.InstanceOf<IRepositoryFactory>());
        }

        [Test]
        public void Constructor_RepositoryFactoryGiven_RepositoryFactoryIsSame()
        {
            // Assign
            // Act
            var sut = new MachineService(repositoryFactory.Object);

            // Assert
            Assert.That(() => sut.RepositoryFactory, Is.SameAs(repositoryFactory.Object));
        }
    }
}
