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
            ResetComponents();

            return pizzaType switch
            {
                // Handmade pizzas
                PizzaTypesEnum.Margheritta => Get(Margherita),

                // Frozen pizzas
                PizzaTypesEnum.OetkerRistorantePollo => Get(DrOetkerRistorantePollo),

                // Default empty type
                _ => this._pizza
            };
        }

        public void ResetComponents()
        {
            this._pizza.Components.Clear();
        }

        // ------------
        // IFoodBuilder
        // ------------

        public void InitializeProduct(string name, ushort weightInGrams)
        {
            this._pizza.Name = name;
            this._pizza.WeightInGrams = weightInGrams;

            // Cooking methods
            ResetComponents();
            this._pizza.PreparationMethods.AddRange(new[]
            {
                new PreparationMethod { Type = PreparingMethodEnum.MicrovaweProcessing,  CookingTimeInMinutes = 7 },
                new PreparationMethod { Type = PreparingMethodEnum.CookingInOvenWithFan, CookingTimeInMinutes = 11, TemperatureInC = 200 },
                new PreparationMethod { Type = PreparingMethodEnum.CookingInOven,        CookingTimeInMinutes = 14, TemperatureInC = 220 }
            });

            this._pizza.NutriScore = NutriScoreEnum.C;
        }

        public void AddSpices(params Spice[] spices)
        {
            this._pizza.Components.AddRange(spices);
        }

        public void AddHerbs(params Herb[] herbs)
        {
            this._pizza.Components.AddRange(herbs);
        }

        public void AddIngredients(params BaseIngredient[] ingredients)
        {
            this._pizza.Components.AddRange(ingredients);
        }

        // --------------
        // Custom recipes
        // --------------

        private Pizza Get(Action buildMethod)
        {
            buildMethod();

            return this._pizza;
        }

        private void Margherita()
        {
            InitializeProduct("Margherita", 300);

            AddIngredients(new BaseIngredient[]
            {
                new IngredientLiquid { Type = IngredientsEnum.TomatoSauce,  Amount = 150 },
                new IngredientSolid  { Type = IngredientsEnum.EdamerCheese, Amount = 150 },
                new IngredientSolid  { Type = IngredientsEnum.Tomatoes,     Amount = 100 }
            });

            AddHerbs(new Herb { Type = HerbsEnum.Basilicum, Grams = 5 });
        }

        private void DrOetkerRistorantePollo()
        {
            InitializeProduct("Dr. Oetker Ristorante Pollo Pizza", 355);
        }
    }
}
