using Factory.Exercise.Factories;
using System.Collections.Generic;

namespace Factory.Exercise.Services
{
    public interface ICollectingService
    {
        /// <summary>
        /// Add product to the list
        /// </summary>
        /// <param name="product"></param>
        public void AddProduct(IProduct product);

        /// <summary>
        /// Get current product list
        /// </summary>
        /// <returns></returns>
        public IList<IProduct> GetCurrentProducts();
    }
}
