namespace Ogd.Virarium.Tests.Common.Layering.ServiceLayer
{
    using System.Linq;
    using Moq;
    using NUnit.Framework;
    using Ogd.Virarium.Common.Layering.Business;
    using Ogd.Virarium.Common.Layering.Persistence;
    using Ogd.Virarium.Common.Layering.Service;

    [TestFixture]
    public abstract class IServiceTests<TEntity>
        where TEntity : class, IIdentifiable, new()
    {
        protected abstract IService<TEntity> CreateServiceImplementation(IRepositoryFactory repositoryFactory);

        [Test]
        public virtual void GetAll_ReturnsCollectionOfT()
        {
            // Assign
            var repository = new Mock<IRepository<TEntity>>();
            repository
                .Setup(x => x.GetAll())
                .Returns(() => new TEntity[] { }.AsQueryable());
            var repositoryFactory = new Mock<IRepositoryFactory>();
            repositoryFactory
                .Setup(x => x.GetRepository<TEntity>())
                .Returns(() => repository.Object);
            var sut = CreateServiceImplementation(repositoryFactory.Object);

            // Act
            var result = sut.GetAll();

            // Assert
            Assert.That(() => result, Is.InstanceOf<IQueryable<TEntity>>());
        }

        [Test]
        public virtual void Find_VerifyRepositoryFindIsCalled()
        {
            // Assign
            var repository = new Mock<IRepository<TEntity>>();
            var repositoryFactory = new Mock<IRepositoryFactory>();
            repositoryFactory
                .Setup(x => x.GetRepository<TEntity>())
                .Returns(() => repository.Object);
            var sut = CreateServiceImplementation(repositoryFactory.Object);

            // Act
            var result = sut.Find(1);

            // Assert
            repository.Verify(x => x.GetById(It.IsAny<int>()), Times.Once());
        }

        [Test]
        public virtual void Exists_VerifyRepositoryAllIncludingIsCalled()
        {
            // Assign
            var repository = new Mock<IRepository<TEntity>>();
            var repositoryFactory = new Mock<IRepositoryFactory>();
            repositoryFactory
                .Setup(x => x.GetRepository<TEntity>())
                .Returns(() => repository.Object);
            var sut = CreateServiceImplementation(repositoryFactory.Object);

            // Act
            var result = sut.Exists(x => x.Id == 1);

            // Assert
            repository.Verify(x => x.GetAll(), Times.Once());
        }

        [Test]
        public virtual void Create_VerifyRepositoryInsertOrUpdateIsCalled()
        {
            // Assign
            var entity = new TEntity();
            var repository = new Mock<IRepository<TEntity>>();
            var repositoryFactory = new Mock<IRepositoryFactory>();
            repositoryFactory
                .Setup(x => x.GetRepository<TEntity>())
                .Returns(() => repository.Object);
            var sut = CreateServiceImplementation(repositoryFactory.Object);

            // Act
            sut.Create(entity);

            // Assert
            repository.Verify(x => x.Save(It.IsAny<TEntity>()), Times.Once());
        }

        [Test]
        public virtual void Update_VerifyRepositoryInsertOrUpdateIsCalled()
        {
            // Assign
            var entity = new TEntity();
            var repository = new Mock<IRepository<TEntity>>();
            var repositoryFactory = new Mock<IRepositoryFactory>();
            repositoryFactory
                .Setup(x => x.GetRepository<TEntity>())
                .Returns(() => repository.Object);
            var sut = CreateServiceImplementation(repositoryFactory.Object);

            // Act
            sut.Update(entity);

            // Assert
            repository.Verify(x => x.Update(It.IsAny<TEntity>()), Times.Once());
        }

        [Test]
        public virtual void Delete_VerifyRepositoryDeleteIsCalled()
        {
            // Assign
            var entity = new TEntity();
            var repository = new Mock<IRepository<TEntity>>();
            var repositoryFactory = new Mock<IRepositoryFactory>();
            repositoryFactory
                .Setup(x => x.GetRepository<TEntity>())
                .Returns(() => repository.Object);
            var sut = CreateServiceImplementation(repositoryFactory.Object);

            // Act
            sut.Delete(entity);

            // Assert
            repository.Verify(x => x.Delete(It.IsAny<TEntity>()), Times.Once());
        }
    }
}
