using Factory.Exercise.Factories;
using System;
using System.Collections.Generic;

namespace Factory.Exercise.Services
{
    // TODO: From this class, please use your ProductsFactory
    public sealed class ShoppingCart : ICollectingService
    {
        private readonly ProductsFactory _productsFactory = new ProductsFactory(); // why need product factory here?
        private IList<IProduct> _shoppingCart = new List<IProduct>();

        public void AddProduct(IProduct product)
        {
            /* TODO: This method should:
             * 1. Add
             * 2. A specific product
             * 3. To the collection of products (shopping cart) */
            
            _shoppingCart.Add(product);
        }

        public IList<IProduct> GetCurrentProducts()
        {
            // TODO: This method should return a collection of products currently added to the shopping cart

            return _shoppingCart;
        }
    }
}
