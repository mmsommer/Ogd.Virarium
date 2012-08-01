namespace Ogd.Virarium.Tests.Common.Presentation
{
    using System;
    using NUnit.Framework;
    using Ogd.Virarium.Common.Layering.Presentation;

    [TestFixture]
    public abstract class BaseControllerTests
    {
        protected abstract BaseController CreateImplementation();

        [Test]
        public void Map_WithObject_ThrowsNoException()
        {
            // Arrange
            var sut = CreateImplementation();

            // Act 
            var testDelegate = new TestDelegate(() => sut.Map<object, object>(new object()));

            // Assert
            Assert.That(testDelegate, Throws.Nothing);
        }

        [Test]
        public void Map_WithNullObject_ThrowsArgumentNullException()
        {
            // Arrange
            var sut = CreateImplementation();

            // Act 
            var testDelegate = new TestDelegate(() => sut.Map<object, object>(null));

            // Assert
            Assert.That(testDelegate, Throws.TypeOf<ArgumentNullException>());
        }
    }
}
