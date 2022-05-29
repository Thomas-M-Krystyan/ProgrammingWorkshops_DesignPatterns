using Builder.Exercise.Products.Interfaces;

namespace Builder.Exercise.Products.Implementations.Meals.Models.Base
{
    /// <summary>
    /// Base class for meal products.
    /// </summary>
    /// <seealso cref="IProduct" />
    public abstract class BaseMeal : IProduct
    {
        public string Name { get; set; }
    }
}
