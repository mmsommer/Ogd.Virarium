using Moq;
using NHibernate;
using NHibernate.Cfg;
using NUnit.Framework;
using Ogd.Virarium.Common.Layering.Persistence;

namespace Ogd.Virarium.Common.Tests.Layering.Persistence
{
    [TestFixture]
    public abstract class INHibernateHelperTests
    {
        public abstract INHibernateHelper CreateINHibernateImplementation();

        [Test]
        public void Test_Configuration_IsNotNull()
        {
            var sut = CreateINHibernateImplementation();

            Assert.That(sut.Configuration, Is.Not.Null);
        }

        [Test]
        public void Test_Configuration_IsOfTypeConfiguration()
        {
            var sut = CreateINHibernateImplementation();

            Assert.That(sut.Configuration, Is.InstanceOf<Configuration>());
        }

        [Test]
        public void Test_SessionFactory_IsNotNull()
        {
            var sut = CreateINHibernateImplementation();

            Assert.That(sut.SessionFactory, Is.Not.Null);
        }

        [Test]
        public void Test_SessionFactory_IsOfTypeISessionFactory()
        {
            var sut = CreateINHibernateImplementation();

            Assert.That(sut.SessionFactory, Is.InstanceOf<ISessionFactory>());
        }

        [Test]
        public void Test_RollBack_SessionGiven_DoesNotThrowException()
        {
            // Assign
            var sessionMock = new Mock<ISession>();
            var sut = CreateINHibernateImplementation();

            // Act
            // Assert
            Assert.That(() => sut.RollBack(sessionMock.Object), Throws.Nothing);
        }

        [Test]
        public void Test_Flush_SessionGiven_DoesNotThrowException()
        {
            var sessionMock = new Mock<ISession>();
            var sut = CreateINHibernateImplementation();

            sut.Flush(sessionMock.Object);
        }

        [Test]
        public void Test_Configure_ConfigurationNotGiven_DoesNotThrowException()
        {
            var sut = CreateINHibernateImplementation();

            sut.Configure();
        }

        [Test]
        public void Test_Configure_ConfigurationNotGiven_ReturnsNotNull()
        {
            var sut = CreateINHibernateImplementation();

            Assert.That(sut.Configure(), Is.Not.Null);
        }

        [Test]
        public void Test_Configure_ConfigurationNotGiven_ReturnsInstanceOfConfiguration()
        {
            var sut = CreateINHibernateImplementation();

            Assert.That(sut.Configure(), Is.InstanceOf<Configuration>());
        }
    }
}
