using Factory.Exercise.Abstractions;
using Factory.Exercise.Factories;
using Factory.Exercise.Models;
using NUnit.Framework;
using System;
using System.Reflection;

namespace FactoryTests
{
    [TestFixture]
    public class ProductsFactoryTests
    {
        private ProductsFactory _factory;

        [OneTimeSetUp]
        public void InitializeTests()
        {
            this._factory = new ProductsFactory();
        }

        [TestCase(typeof(WholeGrainBread), "Whole Grain Bread", "0.75 kg", "€ 1.65")]
        [TestCase(typeof(ToastBread), "Toast Bread", "1 kg", "€ 1.20")]
        [TestCase(typeof(GoudaCheese), "Gouda Cheese", "0.5 kg", "€ 4.75")]
        [TestCase(typeof(EdamerCheese), "Edamer Cheese", "0.5 kg", "€ 4.25")]
        [TestCase(typeof(LowFatMilk), "Low-Fat Milk (2%)", "1 l", "€ 1.08")]
        [TestCase(typeof(HighFatMilk), "High-Fat Milk (3.5%)", "1 l", "€ 1.20")]
        public void Check_Method_Get_ForWholeGrainBread_ReturnsExpectedModelType(Type type, string name, string unit, string price)
        {
            // NOTE: The reflection mechanism is used to invoke _factory.Get<T> method with parameter-based types in test cases

            // Arrange
            var factoryGetMethod = this._factory.GetType().GetMethod(nameof(this._factory.Get), BindingFlags.Instance | BindingFlags.Public);
            factoryGetMethod = factoryGetMethod.MakeGenericMethod(type);

            // Act
            var result = (ProductBase)factoryGetMethod.Invoke(this._factory, null);

            // Assert
            Assert.That(result.GetType(), Is.EqualTo(type));
            Assert.That(result.GetName(), Is.EqualTo(name));
            Assert.That(result.GetUnit(), Is.EqualTo(unit));
            Assert.That(result.GetPriceEur(), Is.EqualTo(price));
        }
    }
}
