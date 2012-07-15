using NUnit.Framework;
using Ogd.Virarium.Common.Layering.Business;
using Ogd.Virarium.Common.Layering.Persistence;

namespace Ogd.Virarium.Common.Tests.Layering.Persistence
{
    [TestFixture]
    public abstract class IRepositoryFactoryTest
    {
        protected abstract IRepositoryFactory CreateDaoFactoryImplementation();

        [Test]
        public void Test_CreateDao_ShouldNotThrowException()
        {
            var sut = CreateDaoFactoryImplementation();

            Assert.That(() => sut.GetRepository<IIdentifiable>(), Throws.Nothing);
        }

        [Test]
        public void Test_CreateDao_ShouldReturnIDao()
        {
            var sut = CreateDaoFactoryImplementation();

            Assert.That(sut.GetRepository<IIdentifiable>(), Is.InstanceOf<IRepository<IIdentifiable>>());
        }
    }
}
