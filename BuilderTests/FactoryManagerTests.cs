using Builder.Exercise.Factory.Handler;
using Builder.Exercise.Factory.Implementations;
using Builder.Exercise.Products.Implementations.Meals.Models;
using Builder.Exercise.Products.Implementations.Meals.Models.Base;
using Builder.Exercise.Products.Implementations.Vehicles.Enums;
using Builder.Exercise.Products.Implementations.Vehicles.Models;
using Builder.Exercise.Products.Interfaces;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Reflection;

namespace BuilderTests
{
    [TestFixture]
    public class FactoryManagerTests
    {
        private FactoryManager _factoryManager;

        [SetUp]
        public void InitializeTests()
        {
            this._factoryManager = new FactoryManager(new ConcreteFactory());
        }

        [TestCase(typeof(Pizza))]
        [TestCase(typeof(Bike))]
        public void TestMethod_Create_ReturnsBasicObject(Type type)
        {
            // Arrange

            /* NOTE: Reflection is the way of passing generic type <T> as a Type parameter to handle multiple test cases
                     instead of creating many test methods passing a specific generic type explicitly to a tested method */
            MethodInfo method = this._factoryManager.GetType()
                                                    .GetMethod(nameof(this._factoryManager.Create))
                                                    .MakeGenericMethod(new Type[] { type });
            // Act
            IProduct product = method.Invoke(this._factoryManager, Array.Empty<object>()) as IProduct;

            // Assert
            Assert.That(product.GetType(), Is.EqualTo(type));
        }

        [Test]
        public void TestMethod_Create_OetkerRistorantePollo_ReturnsExpectedPizzaType()
        {
            // Act
            ReadyMeal product = this._factoryManager.Create<OetkerRistorantePollo>() as ReadyMeal;

            // Assert
            string actualSerializedProduct = JsonConvert.SerializeObject(product);  // NOTE: Serializing (public) properties to not check them one-by-one
            const string expectedSerializedProuct =
                "{\"WeightInGrams\":355,\"PreparationMethods\":[{\"Type\":4,\"TemperatureInC\":null,\"CookingTimeInMinutes\":7}," +
                "{\"Type\":3,\"TemperatureInC\":200,\"CookingTimeInMinutes\":11},{\"Type\":2,\"TemperatureInC\":220,\"CookingTimeInMinutes\":14}]," +
                "\"NutriScore\":2,\"Components\":[],\"Name\":\"Dr. Oetker Ristorante Pollo Pizza\"}";

            Assert.That(product.GetType(), Is.EqualTo(typeof(OetkerRistorantePollo)));
            Assert.That(actualSerializedProduct, Is.EqualTo(expectedSerializedProuct));
        }

        [Test]
        public void TestMethod_Create_MountainBike_Black_ReturnsExpectedBikeType()
        {
            // Act
            Bike product = this._factoryManager.Create<MountainBike>() as Bike;
            product.Color = ColorEnum.Black;

            // Assert
            string actualSerializedProduct = JsonConvert.SerializeObject(product);  // NOTE: Serializing (public) properties to not check them one-by-one
            const string expectedSerializedProuct =
                "{\"Name\":\"Mountain bike\",\"WeightInKg\":12.5,\"Wheels\":2,\"Doors\":0,\"Color\":4}";

            Assert.That(product.GetType(), Is.EqualTo(typeof(MountainBike)));
            Assert.That(actualSerializedProduct, Is.EqualTo(expectedSerializedProuct));
        }

        [Test]
        public void TestMethod_Create_ForNullFactory_DoesNotThrowNullReferenceException_ReturnsDefaultProduct()
        {
            // Arrange
            this._factoryManager = new FactoryManager(null);

            // Act
            IProduct product = this._factoryManager.Create<MountainBike>();

            // Assert
            Assert.That(product, Is.EqualTo(default(IProduct)));
        }
    }
}
