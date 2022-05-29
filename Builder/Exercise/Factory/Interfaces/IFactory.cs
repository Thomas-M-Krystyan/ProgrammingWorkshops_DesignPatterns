using Builder.Exercise.Products.Interfaces;

namespace Builder.Exercise.Factory.Interfaces
{
    public interface IFactory
    {
        T Create<T>() where T : IProduct, new();
    }
}
