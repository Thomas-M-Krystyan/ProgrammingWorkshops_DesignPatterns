using Builder.Exercise.Product.Implementations.Meals.Enums;
using Builder.Exercise.Product.Implementations.Meals.Models.Base;
using System.Collections.Generic;

namespace Builder.Exercise.Product.Implementations.Meals.Models
{
    public sealed class ReadyMeal : BaseMeal
    {
        public ushort WeightInKg { get; set; }

        public (ushort Min, ushort Max) CookingTimeInMinutes { get; set; }

        public ICollection<(PreparingMethodEnum, ushort)> CookingTemperatureInC { get; set; }

        public NutriScoreEnum NutriScore { get; set; }
    }
}
