using Facade.Services.Mathematics;
using Microsoft.Extensions.Logging.Abstractions;
using NUnit.Framework;

namespace FacadeTests.Services
{
    [TestFixture]
    public class Tests
    {
        private AddingService _service;

        [SetUp]
        public void Setup()
        {
            this._service = new AddingService(new NullLogger<AddingService>());
        }

        [Test]
        public void Method_Calculate_ForIntNumbers_ReturnsExpectedSum()
        {
            // Act
            var result = this._service.Calculate(1, 2, 3, 4);

            // Assert
            Assert.That(result, Is.EqualTo(10));
        }

        [Test]
        public void Method_Calculate_ForFloatNumbers_ReturnsExpectedSum()
        {
            // Act
            var result = this._service.Calculate(0.5f, 2.5f, 3.1f, 3.9f);

            // Assert
            Assert.That(result, Is.EqualTo(10.0f));
        }

        [Test]
        public void Method_Calculate_ForDoubleNumbers_ReturnsExpectedSum()
        {
            // Act
            var result = this._service.Calculate(0.75D, 2.25D, 2.91D, 4.09D);

            // Assert
            Assert.That(result, Is.EqualTo(10.0D));
        }

        [Test]
        public void Method_Calculate_ForDecimalNumbers_ReturnsExpectedSum()
        {
            // Act
            var result = this._service.Calculate(0.75M, 2.25M, 2.91M, 4.09M);

            // Assert
            Assert.That(result, Is.EqualTo(10.0M));
        }

        [Test]
        public void Method_Calculate_ForObjects_ReturnsDefault_DoesNotThrowException()
        {
            // Act
            var result = this._service.Calculate(new object(), null, null);

            // Assert
            Assert.That(result, Is.Null);
        }
    }
}
