using Builder.Exercise.Builder.Interfaces;
using Builder.Exercise.Components.Implementations.Models;
using Builder.Exercise.Components.Implementations.Models.Base;
using Builder.Exercise.Products.Implementations.Meals.Enums;
using Builder.Exercise.Products.Implementations.Meals.Enums.ProductTypes;
using Builder.Exercise.Products.Implementations.Meals.Models;
using System;

namespace Builder.Exercise.Builder.Implementations
{
    public sealed class PizzaBuilder : IBuilder<Pizza, PizzaTypesEnum>, IFoodBuilder
    {
        private readonly Pizza _pizza = new();

        // -----------
        // IBuilder<T>
        // -----------

        public Pizza Build(PizzaTypesEnum pizzaType)
        {
            throw new NotImplementedException();
        }

        public void ResetComponents()
        {
            throw new NotImplementedException();
        }

        // ------------
        // IFoodBuilder
        // ------------

        public void InitializeProduct(string name, ushort weightInGrams)
        {
            throw new NotImplementedException();
        }

        public void AddSpices(params Spice[] spices)
        {
            throw new NotImplementedException();
        }

        public void AddHerbs(params Herb[] herbs)
        {
            throw new NotImplementedException();
        }

        public void AddIngredients(params BaseIngredient[] ingredients)
        {
            throw new NotImplementedException();
        }
    }
}
