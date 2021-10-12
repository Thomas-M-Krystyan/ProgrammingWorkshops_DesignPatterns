using Factory.Exercise.Factories;

namespace Factory.Exercise.Models
{
    public sealed class Bread : IProduct
    {
       
        public Bread()
        { 
        }
        public float GetPrice()
        {
            return 2.3f;
        }

        public string GetProductName()
        {
            return "Bread";

        }

        public float GetWeight()
        {
            return 2.0f;
        }
    }
}
