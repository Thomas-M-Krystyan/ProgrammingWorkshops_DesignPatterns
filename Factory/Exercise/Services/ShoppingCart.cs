using Factory.Exercise.Interfaces;
using System.Collections.Generic;

namespace Factory.Exercise.Services
{
    /// <summary>
    /// The shopping cart with products.
    /// </summary>
    /// <seealso cref="ICollectingService" />
    public sealed class ShoppingCart : ICollectingService
    {
        private readonly IList<IProduct> _shoppingCart = new List<IProduct>();
        private readonly IFactory _factory;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShoppingCart"/> class.
        /// </summary>
        /// <param name="factory">The implementation of factory.</param>
        public ShoppingCart(IFactory factory)
        {
            this._factory = factory;
        }

        /// <inheritdoc />
        public void AddProduct<T>() where T : IProduct, new()
        {
            // Create product
            var product = this._factory.Get<T>();

            // Add to shopping cart
            this._shoppingCart.Add(product);
        }

        /// <inheritdoc />
        public IList<IProduct> GetCurrentProducts()
        {
            return this._shoppingCart;
        }
    }
}
