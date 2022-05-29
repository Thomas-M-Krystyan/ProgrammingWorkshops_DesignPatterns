using Builder.Exercise.Components.Interfaces;
using Builder.Exercise.Products.Implementations.Meals.Enums;

namespace Builder.Exercise.Components.Implementations.Models.Base
{
    public abstract class BaseIngredient : IComponent
    {
        public IngredientsEnum Type { get; set; }

        public abstract ushort Amount { get; set; }
    }
}
