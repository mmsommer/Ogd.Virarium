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
    public class VLanServiceTests : IServiceTests<VLan>
    {
        Mock<IRepositoryFactory> repositoryFactory { get; set; }

        protected override IService<VLan> CreateServiceImplementation(IRepositoryFactory repositoryFactory)
        {
            return new VLanService(repositoryFactory);
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
            var sut = new VLanService();

            // Assert
            Assert.That(() => sut.RepositoryFactory, Is.InstanceOf<IRepositoryFactory>());
        }

        [Test]
        public void Constructor_RepositoryFactoryGiven_RepositoryFactoryIsSame()
        {
            // Assign
            // Act
            var sut = new VLanService(repositoryFactory.Object);

            // Assert
            Assert.That(() => sut.RepositoryFactory, Is.SameAs(repositoryFactory.Object));
        }
    }
}
