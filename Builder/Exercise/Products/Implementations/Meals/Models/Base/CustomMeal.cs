using Builder.Exercise.Components.Interfaces;
using Builder.Exercise.Products.Interfaces;
using System.Collections.Generic;

namespace Builder.Exercise.Products.Implementations.Meals.Models.Base
{
    public abstract class CustomMeal : BaseMeal, IProductComponentized
    {
        public List<IComponent> Components { get; } = new List<IComponent>();
    }
}
