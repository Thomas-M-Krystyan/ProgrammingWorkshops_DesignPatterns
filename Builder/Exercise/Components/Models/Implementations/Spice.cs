using Builder.Exercise.Components.Interfaces;
using Builder.Exercise.Products.Implementations.Meals.Enums;

namespace Builder.Exercise.Components.Implementations.Models
{
    public sealed class Spice : IComponent
    {
        public SpicesEnum Type { get; set; }

        public ushort Grams { get; set; }
    }
}
