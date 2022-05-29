using Builder.Exercise.Products.Implementations.Meals.Enums;
using System.Collections.Generic;

namespace Builder.Exercise.Products.Implementations.Meals.Models.Base
{
    public abstract class ReadyMeal : CustomMeal
    {
        public ushort WeightInGrams { get; set; }

        public List<PreparationMethod> PreparationMethods { get; } = new List<PreparationMethod>();

        public NutriScoreEnum NutriScore { get; set; }
    }
}
