using Factory.Exercise.Interfaces;
using Factory.Exercise.Models;
using Factory.Exercise.Services;
using Moq;
using NUnit.Framework;

namespace FactoryTests
{
    [TestFixture]
    public class CollectingServicesTests
    {
        private ICollectingService _shoppingCart;
        private ICollectingService _wishlist;

        [OneTimeSetUp]
        public void InitializeTests()
        {
            var factory = new Mock<IFactory>().Object;

            this._shoppingCart = new ShoppingCart(factory);
            this._wishlist = new Wishlist(factory);
        }

        [Test]
        public void Check_ShoppingCart_Method_AddProduct_ReturnsExpectedProducts()
        {
            // Act
            this._shoppingCart.AddProduct<ToastBread>();
            this._shoppingCart.AddProduct<GoudaCheese>();
            this._shoppingCart.AddProduct<HighFatMilk>();

            var productsCount = this._shoppingCart.GetCurrentProducts().Count;

            // Assert
            Assert.That(productsCount, Is.EqualTo(3));
        }

        [Test]
        public void Check_Wishlist_Method_AddProduct_ReturnsExpectedProducts()
        {
            // Act
            this._wishlist.AddProduct<GoudaCheese>();
            this._wishlist.AddProduct<EdamerCheese>();

            var productsCount = this._wishlist.GetCurrentProducts().Count;

            // Assert
            Assert.That(productsCount, Is.EqualTo(2));
        }
    }
}
