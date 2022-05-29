using Builder.Exercise.Factory.Interfaces;
using Builder.Exercise.Products.Interfaces;

namespace Builder.Exercise.Factory.Implementations
{
    public sealed class ConcreteFactory : IFactory
    {
        public T Create<T>() where T : IProduct, new()
        {
            return new T();
        }
    }
}
