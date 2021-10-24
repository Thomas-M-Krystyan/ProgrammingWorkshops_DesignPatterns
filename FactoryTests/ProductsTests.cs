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
        [Test]
        public void Model_Bread_ForValidInput_ReturnsExpectedValues()
        {
            // Act
            var model = new Bread(BreadTypes.Toast, 1, 1.65M);

            // Assert
            var actualSerializedModelData = JsonSerializer.Serialize(model);
            var expectedSerializedModelData = "{\"Type\":{},\"WeightKg\":1,\"PriceEur\":1.65}";

            Assert.That(actualSerializedModelData, Is.EqualTo(expectedSerializedModelData));

            Assert.That(model.GetName(), Is.EqualTo("Toast Bread"));
            Assert.That(model.GetType(), Is.EqualTo("Toast"));
            Assert.That(model.GetWeightInKg(), Is.EqualTo("1 kg"));
            Assert.That(model.GetWeightInLb(), Is.EqualTo("2.20 lb"));
            Assert.That(model.GetPriceInEur(), Is.EqualTo("€ 1.65"));
        }

        [TestCase((BreadTypes)(-1))]
        [TestCase((BreadTypes)9999)]
        public void Model_Bread_ForInvalidType_ReturnExceptions(BreadTypes invalidType)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Bread(invalidType, 1, 1));
        }
    }
}
