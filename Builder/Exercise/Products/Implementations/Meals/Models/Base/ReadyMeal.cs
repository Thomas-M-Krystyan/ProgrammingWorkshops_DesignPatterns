using Builder.Exercise.Products.Implementations.Meals.Enums;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Builder.Exercise.Products.Implementations.Meals.Models.Base
{
    public abstract class ReadyMeal : CustomMeal
    {
        [JsonProperty(Order = 3)]
        public ushort WeightInGrams { get; set; }
        [JsonProperty(Order = 2)]
        public List<PreparationMethod> PreparationMethods { get; } = new List<PreparationMethod>();
        [JsonProperty(Order = 1)]
        public NutriScoreEnum NutriScore { get; set; }
    }
}
