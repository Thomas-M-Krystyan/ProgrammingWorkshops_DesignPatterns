using Factory.Exercise.Factories;

namespace Factory.Exercise.Models
{
    public sealed class Milk : IProduct
    {

        public Milk()
        {
        }
        public float GetPrice()
        {
            return 1.5f;
        }

        public string GetProductName()
        {
            return "Milk";

        }

        public float GetWeight()
        {
            return 1.0f;
        }
    }
}
