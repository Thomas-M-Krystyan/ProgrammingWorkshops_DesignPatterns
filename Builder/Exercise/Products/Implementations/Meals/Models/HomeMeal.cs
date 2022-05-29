using Builder.Exercise.Products.Implementations.Meals.Models.Base;
using Builder.Exercise.Products.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;

namespace Builder.Exercise.Products.Implementations.Meals.Models
{
    public sealed class HomeMeal : BaseMeal, IProductComponentized
    {
        public ICollection<IComponent> Components { get; }
    }
}
