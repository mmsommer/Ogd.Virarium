﻿namespace Ogd.Virarium.Tests.Data
{
    using Moq;
    using NHibernate;
    using NHibernate.Cfg;
    using NUnit.Framework;
    using Ogd.Virarium.Common.Layering.Persistence;
    using Ogd.Virarium.Data;
    using Ogd.Virarium.Tests.Common.Layering.Persistence;

    public class NHibernateHelperTests : INHibernateHelperTests
    {
        public override INHibernateHelper CreateINHibernateImplementation()
        {
            return new NHibernateHelper();
        }

        [Test]
        public void Test_Constructor_ConfigurationGiven_ConfigurationIsSame()
        {
            // Assign
            var configuration = new Configuration();

            // Act
            var sut = new NHibernateHelper(configuration);

            // Assert
            Assert.That(() => sut.Configuration, Is.SameAs(configuration));
        }

        [Test]
        public void Test_Constructor_ConfigurationNotGiven_ConfigurationIsSet()
        {
            // Assign
            // Act
            var sut = new NHibernateHelper();

            // Assert
            Assert.That(() => sut.Configuration, Is.InstanceOf<Configuration>());
        }

        [Test]
        public void Test_Configuration_ConfigurationSet_SetConfigurationReturned()
        {
            var configuration = new Configuration();
            var sut = CreateINHibernateImplementation();
            sut.Configure(configuration);

            Assert.That(sut.Configuration, Is.SameAs(configuration));
        }

        [Test]
        public void Test_Configuration_StaticConfigurationNotSet_NewConfigurationReturned()
        {
            var sut = CreateINHibernateImplementation();

            Assert.That(sut.Configuration, Is.InstanceOf<Configuration>());
        }

        [Test]
        public void Test_SessionFactory_StaticSessionFactorySet_SetSessionFactoryReturned()
        {
            var sut = CreateINHibernateImplementation();
            var sessionFactory = new Mock<ISessionFactory>().Object;
            NHibernateHelper._instance = sessionFactory;

            Assert.That(sut.SessionFactory, Is.SameAs(sessionFactory));
        }

        [Test]
        public void Test_SessionFactory_StaticSessionFactoryNotSet_NewSessionFactoryReturned()
        {
            var sut = CreateINHibernateImplementation();

            Assert.That(sut.SessionFactory, Is.InstanceOf<ISessionFactory>());
        }

        [Test]
        public void Test_SessionFactory_StaticSessionFactoryNotSet_StaticSessionFactorySet()
        {
            var sut = CreateINHibernateImplementation();
            var sessionFactory = sut.SessionFactory;

            Assert.That(NHibernateHelper._instance, Is.InstanceOf<ISessionFactory>());
        }

    }
}
