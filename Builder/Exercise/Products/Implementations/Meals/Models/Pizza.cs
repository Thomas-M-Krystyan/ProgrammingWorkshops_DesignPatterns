using Builder.Exercise.Products.Implementations.Meals.Enums;
using Builder.Exercise.Products.Implementations.Meals.Models.Base;

namespace Builder.Exercise.Products.Implementations.Meals.Models
{
    public class Pizza : ReadyMeal
    {
    }

    public sealed class OetkerRistorantePollo : Pizza
    {
        public OetkerRistorantePollo()
        {
            this.Name = "Dr. Oetker Ristorante Pollo Pizza";
            this.WeightInGrams = 355;
            this.PreparationMethods.AddRange(new []
            {
                new PreparationMethod { Type = PreparingMethodEnum.MicrovaweProcessing,  CookingTimeInMinutes = 7 },
                new PreparationMethod { Type = PreparingMethodEnum.CookingInOvenWithFan, CookingTimeInMinutes = 11, TemperatureInC = 200 },
                new PreparationMethod { Type = PreparingMethodEnum.CookingInOven,        CookingTimeInMinutes = 14, TemperatureInC = 220 }
            });
            this.NutriScore = NutriScoreEnum.C;
        }
    }
}
