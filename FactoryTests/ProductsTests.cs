using Factory.Exercise.Abstractions;
using Moq;
using NUnit.Framework;
using System;
using System.Reflection;
using System.Text.Json;

namespace FactoryTests
{
    [TestFixture]
    public class ProductsTests
    {
        private const double ValidWeight = 1;
        private const decimal ValidPrice = 1.201M;

        [Test]
        public void Model_Base_ForValidInput_ReturnsExpectedValues()
        {
            // Act
            var model = new Mock<ProductBase>(ValidWeight, ValidPrice).Object;

            // Assert
            var actualSerializedModelData = JsonSerializer.Serialize(model);
            var expectedSerializedModelData = "{\"Unit\":1,\"Price\":1.20}";

            Assert.That(actualSerializedModelData, Is.EqualTo(expectedSerializedModelData));
        }

        [Test]
        public void Model_Base_ForInvalidWeight_ReturnExceptions()
        {
            // Act & Assert
            var baseException = Assert.Throws<TargetInvocationException>(() =>
            {
                _ = new Mock<ProductBase>(-1, ValidPrice).Object;
            });

            Assert.That(baseException.InnerException.GetType, Is.EqualTo(typeof(ArgumentException)));
        }

        [Test]
        public void Model_Base_ForInvalidPrice_ReturnExceptions()
        {
            // Act & Assert
            var baseException = Assert.Throws<TargetInvocationException>(() =>
            {
                _ = new Mock<ProductBase>(ValidWeight, -1M).Object;
            });

            Assert.That(baseException.InnerException.GetType, Is.EqualTo(typeof(ArgumentException)));
        }
    }
}
