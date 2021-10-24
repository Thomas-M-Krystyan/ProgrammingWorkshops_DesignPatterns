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
        private const double ValidWeightInKg = 1;
        private const decimal ValidPriceInEur = 1.20M;

        [Test]
        public void Model_Base_ForValidInput_ReturnsExpectedValues()
        {
            // Act
            var model = new Mock<ProductBase>(ValidWeightInKg, ValidPriceInEur).Object;

            // Assert
            var actualSerializedModelData = JsonSerializer.Serialize(model);
            var expectedSerializedModelData = "{\"WeightKg\":1,\"PriceEur\":1.20}";

            Assert.That(actualSerializedModelData, Is.EqualTo(expectedSerializedModelData));

            Assert.That(model.GetWeightInKg(), Is.EqualTo("1 kg"));
            Assert.That(model.GetWeightInLb(), Is.EqualTo("2.20 lb"));
            Assert.That(model.GetPriceInEur(), Is.EqualTo("€ 1.20"));
        }

        [Test]
        public void Model_Base_ForInvalidWeight_ReturnExceptions()
        {
            // Act & Assert
            var baseException = Assert.Throws<TargetInvocationException>(() =>
            {
                _ = new Mock<ProductBase>(-1, ValidPriceInEur).Object;
            });

            Assert.That(baseException.InnerException.GetType, Is.EqualTo(typeof(ArgumentException)));
        }

        [Test]
        public void Model_Base_ForInvalidPrice_ReturnExceptions()
        {
            // Act & Assert
            var baseException = Assert.Throws<TargetInvocationException>(() =>
            {
                _ = new Mock<ProductBase>(ValidWeightInKg, -1M).Object;
            });

            Assert.That(baseException.InnerException.GetType, Is.EqualTo(typeof(ArgumentException)));
        }
    }
}
