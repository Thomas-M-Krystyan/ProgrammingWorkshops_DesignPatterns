using Factory.Exercise.Interfaces;

namespace Factory.Exercise.Factories
{
    // TODO: In this class implement a proper Factory Design Pattern

    /* TODO: List of products to be supported
     * Milk: Low-Fat 2%, 1 liter, 1.08 €
     * Milk: High-Fat 3.5%, 1 liter, 1.20 €
     */

    /// <summary>
    /// The factory of products.
    /// </summary>
    /// <seealso cref="IFactory" />
    public sealed class ProductsFactory : IFactory
    {
        /// <inheritdoc />
        public IProduct Get<T>() where T : IProduct, new()
        {
            return new T();
        }
    }
}
