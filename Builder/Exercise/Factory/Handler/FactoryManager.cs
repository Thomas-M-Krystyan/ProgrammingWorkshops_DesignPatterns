using Builder.Exercise.Factory.Interfaces;
using Builder.Exercise.Products.Interfaces;

namespace Builder.Exercise.Factory.Handler
{
    /// <summary>
    /// Handles which <see cref="IFactory"/> will be used and which products will be created.
    /// </summary>
    public sealed class FactoryManager  // NOTE: Singleton
    {
        /// <summary>
        /// Creates a basic instance of the <see cref="IProduct"/>.
        /// </summary>
        public IProduct Create<T>() where T : IProduct, new()
        {
            throw new System.NotImplementedException();
        }
    }
}
