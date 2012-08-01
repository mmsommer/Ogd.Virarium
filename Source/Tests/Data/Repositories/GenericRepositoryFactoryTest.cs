namespace Ogd.Virarium.Tests.Data
{
    using Moq;
    using NHibernate;
    using NUnit.Framework;
    using Ogd.Virarium.Common.Layering.Business;
    using Ogd.Virarium.Common.Layering.Persistence;
    using Ogd.Virarium.Data;
    using Ogd.Virarium.Tests.Common.Layering.Persistence;

    public class GenericRepositoryFactoryTest : IRepositoryFactoryTest
    {
        private INHibernateHelper NHibernateHelper { get; set; }

        [SetUp]
        public void Init()
        {
            var stubSession = new Mock<ISession>();
            var stubSessionFactory = new Mock<ISessionFactory>();
            stubSessionFactory
                .Setup(x => x.GetCurrentSession())
                .Returns(() => stubSession.Object);
            var stubNHibernateHelper = new Mock<INHibernateHelper>();
            stubNHibernateHelper
                .Setup(x => x.SessionFactory)
                .Returns(() => stubSessionFactory.Object);
            NHibernateHelper = stubNHibernateHelper.Object;
        }

        protected override IRepositoryFactory CreateDaoFactoryImplementation()
        {
            return new GenericRepositoryFactory(null, NHibernateHelper);
        }

        [Test]
        public void Test_CreateDao_ReturnsGenericDao()
        {
            var sut = CreateDaoFactoryImplementation();

            Assert.That(sut.GetRepository<IIdentifiable>(), Is.InstanceOf<Repository<IIdentifiable>>());
        }
    }
}
