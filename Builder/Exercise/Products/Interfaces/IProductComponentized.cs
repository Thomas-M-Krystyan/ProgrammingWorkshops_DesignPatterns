using Builder.Exercise.Components.Interfaces;
using System.Collections.Generic;

namespace Builder.Exercise.Products.Interfaces
{
    /// <summary>
    /// This interface exposes name of the product and a collection of its components.
    /// </summary>
    /// <seealso cref="IProduct" />
    interface IProductComponentized : IProduct
    {
        List<IComponent> Components { get; }
    }
}
