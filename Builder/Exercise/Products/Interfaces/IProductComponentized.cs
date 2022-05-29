using System.Collections.Generic;
using System.ComponentModel;

namespace Builder.Exercise.Products.Interfaces
{
    /// <summary>
    /// This interface exposes name of the product and a collection of its components.
    /// </summary>
    /// <seealso cref="IProduct" />
    interface IProductComponentized : IProduct
    {
        ICollection<IComponent> Components { get; }
    }
}
