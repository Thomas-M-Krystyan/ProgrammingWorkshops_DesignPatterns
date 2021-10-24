using Factory.Exercise.Abstractions;
using Factory.Exercise.Interfaces;

namespace Factory.Exercise.Factories
{
    // TODO: In this class implement a proper Factory Design Pattern

    /* TODO: List of products to be supported
     * Chease: Gouda, 500 grams, 4.75 €
     * Chease: Edamer, 500 grams, 4.25 €
     * Milk: Low-Fat 2%, 1 liter, 1.08 €
     * Milk: High-Fat 3.5%, 1 liter, 1.20 €
     */

    public sealed class ProductsFactory
    {
        public IProduct Get<T>() where T : ProductBase, new()
        {
            return new T();
        }
    }
}
