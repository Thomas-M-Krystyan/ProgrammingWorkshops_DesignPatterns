using Facade.Services.Mathematics;
using Microsoft.Extensions.Logging.Abstractions;
using NUnit.Framework;

namespace FacadeTests.Services
{
    [TestFixture]
    public class MultiplyingServiceTests
    {
        private MultiplyingService _service;

        [SetUp]
        public void Setup()
        {
            this._service = new MultiplyingService(new NullLogger<MultiplyingService>());
        }
        
        [TestCase(new[] { 1, 2, 3, 4 }, 24)]
        [TestCase(new[] { 0, 0, 0, 0 }, 0)]
        [TestCase(new[] { 0, -0, -0, 0 }, 0)]
        [TestCase(new[] { -1, -2, -3, -4 }, 24)]
        [TestCase(new[] { -1, -2, -3, 0 }, 0)]
        public void Method_Calculate_ForIntNumbers_ReturnsExpectedProduct(int[] numbers, int expectedResult)
        {
            // Act
            var actualResult = this._service.Calculate(numbers);

            // Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Method_Calculate_ForFloatNumbers_ReturnsExpectedProduct()
        {
            // Act
            var actualResult = this._service.Calculate(0.5f, 2.5f, 3.1f, 3.9f);

            // Assert
            Assert.That(actualResult, Is.EqualTo(15.1125f));
        }

        [Test]
        public void Method_Calculate_ForDoubleNumbers_ReturnsExpectedProduct()
        {
            // Act
            var actualResult = this._service.Calculate(0.75D, 2.25D, 2.91D, 4.09D);

            // Assert
            Assert.That(actualResult, Is.EqualTo(20.084456250000002D));
        }

        [Test]
        public void Method_Calculate_ForDecimalNumbers_ReturnsExpectedProduct()
        {
            // Act
            var actualResult = this._service.Calculate(0.75M, 2.25M, 2.91M, 4.09M);

            // Assert
            Assert.That(actualResult, Is.EqualTo(20.08445625M));
        }

        [Test]
        public void Method_Calculate_ForObjects_ReturnsDefault_DoesNotThrowException()
        {
            // Act
            var actualResult = this._service.Calculate(new object(), null, null);

            // Assert
            Assert.That(actualResult, Is.Null);
        }
    }
}
