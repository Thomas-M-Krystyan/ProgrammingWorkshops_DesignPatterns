using Factory.Exercise.Factories;
using System.Collections.Generic;

namespace Factory.Exercise.Services
{
    public interface ICollectingService
    {
        public void AddProduct(IProduct product);

        public IList<IProduct> GetCurrentProducts();
    }
}
