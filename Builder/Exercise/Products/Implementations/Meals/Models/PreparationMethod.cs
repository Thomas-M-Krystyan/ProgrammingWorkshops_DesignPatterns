using Builder.Exercise.Products.Implementations.Meals.Enums;

namespace Builder.Exercise.Products.Implementations.Meals.Models
{
    public sealed class PreparationMethod
    {
        public PreparingMethodEnum Type { get; set; }

        public ushort? TemperatureInC { get; set; }

        public ushort CookingTimeInMinutes { get; set; }
    }
}
