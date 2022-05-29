using Builder.Exercise.Products.Implementations.Meals.Enums;

namespace Builder.Exercise.Components.Implementations
{
    public sealed class PreparationMethod
    {
        public PreparingMethodEnum Type { get; set; }

        public ushort TemperatureInC { get; set; }
    }
}
