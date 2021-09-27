namespace Factory.Exercise.Models
{
    public sealed class Bread
    {
        public string Name()
        {
            return "Whole grain";
        }

        public float WeightInKg()
        {
            return 1450.0f;
        }

        public float PriceInEuro()
        {
            return 1.10f;
        }
    }
}
