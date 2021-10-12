using Factory.Exercise.Models;

namespace Factory.Exercise.Factories
{
    // TODO: In this class implement a proper Factory Design Pattern

    /* TODO: List of products to be supported
     * Chease: Gouda, 500 grams, 4.75 €
     * Chease: Edamer, 500 grams, 4.25 €
     * Milk: Low-Fat 2%, 1 liter, 1.08 €
     * Milk: High-Fat 3.5%, 1 liter, 1.20 €
     * Bread: Whole grains, 750 grams, 1.65 €
     * Bread: Toast, 1 kg, 1.20 € */

    public sealed class ProductsFactory
    {
       public static T Creat<T>() where T : IProduct, new ()
       {
            return new T();
       }
    }
}
