using Builder.Exercise.Product.Interfaces;

namespace Builder.Exercise.Product.Implementations.Meals.Models.Base
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
