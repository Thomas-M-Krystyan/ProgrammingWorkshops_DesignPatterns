using Factory.Exercise.Interfaces;
using System.Collections.Generic;

namespace Factory.Exercise.Services
{
    /// <summary>
    /// The collecting service.
    /// </summary>
    public interface ICollectingService
    {
        /// <summary>
        /// Adds the product to the shopping cart.
        /// </summary>
        /// <typeparam name="T">The type of product.</typeparam>
        public void AddProduct<T>() where T : IProduct, new();

        /// <summary>
        /// Gets the current products from the shopping cart.
        /// </summary>
        public IList<IProduct> GetCurrentProducts();
    }
}
