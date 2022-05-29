using Builder.Exercise.Products.Implementations.Meals.Enums;
using Builder.Exercise.Products.Implementations.Meals.Models.Base;
using System.Collections.Generic;

namespace Builder.Exercise.Products.Implementations.Meals.Models
{
    public sealed class ReadyMeal : BaseMeal
    {
        public ushort WeightInKg { get; set; }

        public (ushort Min, ushort Max) CookingTimeInMinutes { get; set; }

        public ICollection<(PreparingMethodEnum, ushort)> CookingTemperatureInC { get; set; }

        public NutriScoreEnum NutriScore { get; set; }
    }
}
