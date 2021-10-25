using Factory.Exercise.Interfaces;

namespace Factory.Exercise.Factories
{
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
