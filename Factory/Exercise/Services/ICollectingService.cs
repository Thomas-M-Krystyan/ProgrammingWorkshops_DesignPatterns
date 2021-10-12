using System.Collections.Generic;
using Factory.Exercise.Factories;

namespace Factory.Exercise.Services
{
    public interface ICollectingService
    {
        public void AddProduct(IProduct product);

        public IList<IProduct> GetCurrentProducts();
    }
}
