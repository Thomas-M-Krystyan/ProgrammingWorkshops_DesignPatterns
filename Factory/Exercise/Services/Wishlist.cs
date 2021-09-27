using System;
using System.Collections.Generic;

namespace Factory.Exercise.Services
{
    // NOTE: The only purpose of this class is to show you, that "service" is a more general idea, and can
    // be reused with two implementations using similar logic ("add" and "display" from CRUD in this case)
    public sealed class Wishlist : ICollectingService
    {
        public void AddProduct(object product)
        {
            throw new NotImplementedException();
        }

        public IList<object> GetCurrentProducts()
        {
            throw new NotImplementedException();
        }
    }
}
