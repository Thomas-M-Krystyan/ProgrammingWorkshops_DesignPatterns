using Factory.Exercise.Factories;
using System.Collections.Generic;

namespace Factory.Exercise.Services
{
    public sealed class ShoppingCart : ICollectingService
    {
        private readonly IList<IProduct> _shoppingCart = new List<IProduct>();

        public void AddProduct(IProduct product)
        {
            _shoppingCart.Add(product);
        }

        public IList<IProduct> GetCurrentProducts()
        {
            return _shoppingCart;
        }
    }
}
