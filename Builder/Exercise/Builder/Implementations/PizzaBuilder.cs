using Builder.Exercise.Builder.Interfaces;
using Builder.Exercise.Components.Implementations.Models;
using Builder.Exercise.Components.Implementations.Models.Base;
using Builder.Exercise.Products.Implementations.Meals.Enums;
using Builder.Exercise.Products.Implementations.Meals.Enums.ProductTypes;
using Builder.Exercise.Products.Implementations.Meals.Models;

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
            switch (pizzaType)
            {
                case PizzaTypesEnum.Margheritta:
                    GetMargherita();
                    return _pizza;
                case PizzaTypesEnum.OetkerRistorantePollo:
                    GetDrOetker();
                    return _pizza;
            }
            return _pizza;
        }

        public void ResetComponents()
        {
            _pizza.Components.Clear();
        }

        // ------------
        // IFoodBuilder
        // ------------

        public void InitializeProduct(string name, ushort weightInGrams)
        {
            _pizza.Name = name;
            _pizza.WeightInGrams = weightInGrams;
            _pizza.PreparationMethods.AddRange(new[]
             {
                new PreparationMethod { Type = PreparingMethodEnum.MicrovaweProcessing,  CookingTimeInMinutes = 7 },
                new PreparationMethod { Type = PreparingMethodEnum.CookingInOvenWithFan, CookingTimeInMinutes = 11, TemperatureInC = 200 },
                new PreparationMethod { Type = PreparingMethodEnum.CookingInOven,        CookingTimeInMinutes = 14, TemperatureInC = 220 }
            });

            _pizza.NutriScore = NutriScoreEnum.C;
        }

        public void AddSpices(params Spice[] spices)
        {
            _pizza.Components.AddRange(spices);
        }

        public void AddHerbs(params Herb[] herbs)
        {
            _pizza.Components.AddRange(herbs);
        }

        public void AddIngredients(params BaseIngredient[] ingredients)
        {
            _pizza.Components.AddRange(ingredients);
        }

        private void GetMargherita()
        {
            InitializeProduct("Margherita", 300);
            AddIngredients(new BaseIngredient[]
            {
                new IngredientLiquid { Type = IngredientsEnum.TomatoSauce,  Amount = 150 },
                new IngredientSolid  { Type = IngredientsEnum.EdamerCheese, Amount = 150 },
                new IngredientSolid  { Type = IngredientsEnum.Tomatoes,     Amount = 100 }
            });
            AddHerbs(new Herb[] { new Herb() { Type = HerbsEnum.Basilicum, Grams = 5 } });
        }

        private void GetDrOetker()
        {
            InitializeProduct("Dr. Oetker Ristorante Pollo Pizza", 355);
        }


    }
}
