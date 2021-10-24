using Factory.Exercise.Enums;
using Factory.Exercise.Models;
using NUnit.Framework;
using System;
using System.Text.Json;

namespace FactoryTests
{
    [TestFixture]
    public class ProductsTests
    {
        private const BreadTypes ValidBreadType = BreadTypes.Toast;
        private const double ValidWeightInKg = 1;
        private const decimal ValidPriceInEur = 1.20M;

        [Test]
        public void Model_Bread_ForValidInput_ReturnsExpectedValues()
        {
            // Act
            var model = new Bread(ValidBreadType, ValidWeightInKg, ValidPriceInEur);

            // Assert
            var actualSerializedModelData = JsonSerializer.Serialize(model);
            var expectedSerializedModelData = "{\"Type\":{},\"WeightKg\":1,\"PriceEur\":1.20}";

            Assert.That(actualSerializedModelData, Is.EqualTo(expectedSerializedModelData));

            Assert.That(model.GetTypeName(), Is.EqualTo("Toast"));
            Assert.That(model.GetName(), Is.EqualTo("Toast Bread"));
            Assert.That(model.GetWeightInKg(), Is.EqualTo("1 kg"));
            Assert.That(model.GetWeightInLb(), Is.EqualTo("2.20 lb"));
            Assert.That(model.GetPriceInEur(), Is.EqualTo("€ 1.20"));
        }

        [TestCase((BreadTypes)(-1))]
        [TestCase((BreadTypes)9999)]
        public void Model_Bread_ForInvalidType_ReturnExceptions(BreadTypes invalidType)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Bread(invalidType, ValidWeightInKg, ValidPriceInEur));
        }

        [Test]
        public void Model_Bread_ForInvalidWeight_ReturnExceptions()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Bread(ValidBreadType, -1, ValidPriceInEur));
        }

        [Test]
        public void Model_Bread_ForInvalidPrice_ReturnExceptions()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Bread(ValidBreadType, ValidWeightInKg, -1));
        }
    }
}
