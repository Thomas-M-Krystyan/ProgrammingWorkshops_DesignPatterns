using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Exercise.Factories
{
    public interface IProduct
    {
        public string GetProductName();
        public float GetWeight();
        public float GetPrice();
    }
}
