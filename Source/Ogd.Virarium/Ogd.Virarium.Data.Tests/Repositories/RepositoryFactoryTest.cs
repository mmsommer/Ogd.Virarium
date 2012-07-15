using Moq;
using NHibernate;
using NHibernate.Cfg;
using NUnit.Framework;
using Ogd.Virarium.Common.Layering.Business;
using Ogd.Virarium.Common.Layering.Persistence;
using Ogd.Virarium.Common.Tests.Layering.Persistence;

namespace Ogd.Virarium.Data.Tests
{
    public class RepositoryFactoryTest : IRepositoryFactoryTest
    {
        private INHibernateHelper NHibernateHelper { get; set; }

        [SetUp]
        public void Init()
        {
            var stubConfiguration = new Mock<Configuration>();
            var stubSession = new Mock<ISession>();
            var stubSessionFactory = new Mock<ISessionFactory>();
            stubSessionFactory.Setup(x => x.GetCurrentSession())
                .Returns(() => stubSession.Object);
            var stubNHibernateHelper = new Mock<INHibernateHelper>();
            stubNHibernateHelper
                .Setup(x => x.Configure(null))
                .Returns(() => stubConfiguration.Object);
            stubNHibernateHelper
                .Setup(x => x.SessionFactory)
                .Returns(() => stubSessionFactory.Object);
            NHibernateHelper = stubNHibernateHelper.Object;
        }

        protected override IRepositoryFactory CreateDaoFactoryImplementation()
        {
            return new RepositoryFactory(null, null, NHibernateHelper);
        }

        internal IRepositoryFactory CreateDaoFactoryImplementation(IRepositoryFactory daoFactory)
        {
            return new RepositoryFactory(daoFactory, null, NHibernateHelper);
        }

        [Test]
        public void Test_Constructor_FactorySupplied_InternalFactorySet()
        {
            var factory = new Mock<IRepositoryFactory>().Object;

            var sut = new RepositoryFactory(factory, null, NHibernateHelper);

            Assert.That(sut.Factory, Is.SameAs(factory));
        }

        [Test]
        public void Test_GetDao_FactorySupplied_VerifySuppliedFactoryCreateIsCalled()
        {
            var factoryMock = new Mock<IRepositoryFactory>();
            var factory = factoryMock.Object;

            var sut = new RepositoryFactory(factory, null, NHibernateHelper);

            sut.GetRepository<IIdentifiable>();

            factoryMock.Verify(x => x.GetRepository<IIdentifiable>());
        }

        [Test]
        public void Test_GetDao_AllreadyUsed_SameFactoryIsReturned()
        {
            var factoryMock = new Mock<IRepositoryFactory>();
            var factory = factoryMock.Object;

            var sut = new RepositoryFactory(factory, null, NHibernateHelper);

            var firstTime = sut.GetRepository<IIdentifiable>();

            Assert.That(sut.GetRepository<IIdentifiable>(), Is.SameAs(firstTime));
        }
    }
}
