using Factory.Exercise.Abstractions;
using Factory.Exercise.Enums;
using Factory.Exercise.Interfaces;
using Factory.Exercise.Models;
using System;

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
        public IProduct Get<T>(Enum type) where T : ProductBase
        {
            switch (type)
            {
                case BreadTypes.WholeGrains:
                    return new Bread((BreadTypes)type, 0.750D, 1.65M);

                case BreadTypes.Toast:
                    return new Bread((BreadTypes)type, 1, 1.20M);

                default:
                    throw new NotImplementedException($"The type {type} is not supported yet.");
            }

            //var x = Get<Bread>(BreadTypes.Toast);
        }
    }
}
