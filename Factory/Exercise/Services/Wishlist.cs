using Factory.Exercise.Factories;
using System.Collections.Generic;

namespace Factory.Exercise.Services
{
    // NOTE: The only purpose of this class is to show you, that "service" is a more general idea, and can
    // be reused with two implementations using similar logic ("add" and "display" from CRUD in this case)
    public sealed class Wishlist : ICollectingService
    {
        private readonly IList<IProduct> _wishList = new List<IProduct>();
        public void AddProduct(IProduct product)
        {
            _wishList.Add(product);
        }

        public IList<IProduct> GetCurrentProducts()
        {
            return _wishList;
        }
    }
}
