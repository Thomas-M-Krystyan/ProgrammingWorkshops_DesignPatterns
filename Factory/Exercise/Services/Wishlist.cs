using Factory.Exercise.Abstractions;
using Factory.Exercise.Interfaces;
using System.Collections.Generic;

namespace Factory.Exercise.Services
{
    /// <summary>
    /// The wishlist with products.
    /// </summary>
    /// <seealso cref="ICollectingService" />
    public sealed class Wishlist : ICollectingService
    {
        private readonly IList<IProduct> _wishlist = new List<IProduct>();
        private readonly IFactory _factory;

        /// <summary>
        /// Initializes a new instance of the <see cref="Wishlist"/> class.
        /// </summary>
        /// <param name="factory">The implementation of factory.</param>
        public Wishlist(IFactory factory)
        {
            this._factory = factory;
        }

        /// <inheritdoc />
        public void AddProduct<T>() where T : ProductBase, new()
        {
            // Create product
            var product = this._factory.Get<T>();

            // Add to wishlist
            this._wishlist.Add(product);
        }

        /// <inheritdoc />
        public IList<IProduct> GetCurrentProducts()
        {
            return this._wishlist;
        }
    }
}
