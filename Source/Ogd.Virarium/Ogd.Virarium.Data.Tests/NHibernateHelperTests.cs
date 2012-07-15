﻿using Moq;
using NHibernate;
using NHibernate.Cfg;
using NUnit.Framework;
using Ogd.Virarium.Common.Layering.Persistence;
using Ogd.Virarium.Common.Tests.Layering.Persistence;

namespace Ogd.Virarium.Data.Tests
{
    public class NHibernateHelperTests : INHibernateHelperTests
    {
        public override INHibernateHelper CreateINHibernateImplementation()
        {
            return new NHibernateHelper();
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
        public void Test_Configuration_StaticConfigurationSet_SetConfigurationReturned()
        {
            var configuration = new Configuration();
            var sut = CreateINHibernateImplementation();
            NHibernateHelper._configuration = configuration;

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
