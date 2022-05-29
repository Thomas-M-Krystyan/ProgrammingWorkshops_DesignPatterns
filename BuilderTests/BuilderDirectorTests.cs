using Builder.Exercise.Builder.Handler;
using Builder.Exercise.Builder.Implementations;
using Builder.Exercise.Builder.Interfaces;
using Builder.Exercise.Products.Implementations.Meals.Enums.ProductTypes;
using Builder.Exercise.Products.Implementations.Meals.Models;
using Builder.Exercise.Products.Interfaces;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using System;

namespace BuilderTests
{
    [TestFixture]
    public class BuilderDirectorTests
    {
        private BuilderDirector _builderDirector;

        [Test]
        public void TestMethod_Build_FromPizzaBuilder_ForMargheritta_ReturnsExpectedPizzaType()
        {
            // Arrange
            this._builderDirector = GetMockedDirector(PizzaTypesEnum.Margheritta);

            // Act
            Pizza pizza = this._builderDirector.Build(PizzaTypesEnum.Margheritta) as Pizza;

            // Assert
            string actualSerializedProduct = JsonConvert.SerializeObject(pizza);  // NOTE: Serializing (public) properties to not check them one-by-one
            const string expectedSerializedProuct =
                "{\"WeightInGrams\":300,\"PreparationMethods\":[{\"Type\":4,\"TemperatureInC\":null,\"CookingTimeInMinutes\":7}," +
                "{\"Type\":3,\"TemperatureInC\":200,\"CookingTimeInMinutes\":11},{\"Type\":2,\"TemperatureInC\":220," +
                "\"CookingTimeInMinutes\":14}],\"NutriScore\":2,\"Components\":[{\"Amount\":150,\"Type\":29},{\"Amount\":150,\"Type\":1}," +
                "{\"Amount\":100,\"Type\":16},{\"Type\":0,\"Grams\":5}],\"Name\":\"Margherita\"}";

            Assert.That(pizza.GetType(), Is.EqualTo(typeof(Pizza)));
            Assert.That(actualSerializedProduct, Is.EqualTo(expectedSerializedProuct));
        }

        [Test]
        public void TestMethod_Build_FromPizzaBuilder_ForDrOetkerRistorantePollo_ReturnsExpectedPizzaType()
        {
            // Arrange
            this._builderDirector = GetMockedDirector(PizzaTypesEnum.OetkerRistorantePollo);

            // Act
            Pizza pizza = this._builderDirector.Build(PizzaTypesEnum.OetkerRistorantePollo) as Pizza;

            // Assert
            string actualSerializedProduct = JsonConvert.SerializeObject(pizza);  // NOTE: Serializing (public) properties to not check them one-by-one
            const string expectedSerializedProuct =
                "{\"WeightInGrams\":355,\"PreparationMethods\":[{\"Type\":4,\"TemperatureInC\":null,\"CookingTimeInMinutes\":7}," +
                "{\"Type\":3,\"TemperatureInC\":200,\"CookingTimeInMinutes\":11},{\"Type\":2,\"TemperatureInC\":220,\"CookingTimeInMinutes\":14}]," +
                "\"NutriScore\":2,\"Components\":[],\"Name\":\"Dr. Oetker Ristorante Pollo Pizza\"}";

            Assert.That(pizza.GetType(), Is.EqualTo(typeof(Pizza)));
            Assert.That(actualSerializedProduct, Is.EqualTo(expectedSerializedProuct));
        }

        private static BuilderDirector GetMockedDirector(PizzaTypesEnum pizzaType)
        {
            PizzaBuilder pizzaBuilder = new();

            Mock<IBuilder<IProduct, Enum>> mockedBuilder = new();
            mockedBuilder
                .Setup(mock => mock.Build(pizzaType))
                .Returns(pizzaBuilder.Build(pizzaType));  // NOTE: Redirect request from mocked IBuilder to concrete PizzaBuilder

            return new BuilderDirector(mockedBuilder.Object);
        }
    }
}
