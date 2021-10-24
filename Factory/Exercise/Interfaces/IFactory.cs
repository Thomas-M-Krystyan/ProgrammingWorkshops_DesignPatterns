using Factory.Exercise.Abstractions;

namespace Factory.Exercise.Interfaces
{
    public interface IFactory
    {
        /// <summary>
        /// Gets the created product.
        /// </summary>
        /// <typeparam name="T">The type of product.</typeparam>
        IProduct Get<T>() where T : ProductBase, new();
    }
}
