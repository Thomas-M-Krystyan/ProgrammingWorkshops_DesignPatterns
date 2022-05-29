using Builder.Exercise.Factory.Interfaces;
using Builder.Exercise.Products.Interfaces;

namespace Builder.Exercise.Factory.Handler
{
    /// <summary>
    /// Handles which <see cref="IFactory"/> will be used and which products will be created.
    /// </summary>
    public sealed class FactoryManager  // NOTE: Singleton
    {
        public IFactory Factory { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FactoryManager"/> class.
        /// </summary>
        /// <param name="factory">The factory.</param>
        public FactoryManager(IFactory factory)
        {
            this.Factory = factory;
        }

        /// <summary>
        /// Creates a basic instance of the <see cref="IProduct"/>.
        /// </summary>
        public IProduct Create<T>() where T : IProduct, new()
        {
            return this.Factory.Create<T>();
        }
    }
}
