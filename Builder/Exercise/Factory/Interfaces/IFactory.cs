using Builder.Exercise.Product.Interfaces;

namespace Builder.Exercise.Factory.Interfaces
{
    public interface IFactory
    {
        T Create<T>() where T : IProduct, new();
    }
}
