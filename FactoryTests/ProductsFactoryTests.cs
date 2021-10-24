using Factory.Exercise.Enums;
using Factory.Exercise.Factories;
using Factory.Exercise.Models;
using NUnit.Framework;

namespace FactoryTests
{
    [TestFixture]
    public class ProductsFactoryTests
    {
        [TestCase]
        public void Check_Method_Get_ReturnsExpectedModelType()
        {
            // Arrange
            var factory = new ProductsFactory();

            // Act
            var result = factory.Get<Bread>(BreadTypes.Toast);

            // Assert
            Assert.That(result.GetType(), Is.EqualTo(typeof(Bread)));
            Assert.That(result.GetTypeName(), Is.EqualTo("Toast"));
        }
    }
}
