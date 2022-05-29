using Builder.Exercise.Components.Implementations.Models.Base;

namespace Builder.Exercise.Components.Implementations.Models
{
    public sealed class IngredientSolid : BaseIngredient
    {
        /// <summary>
        /// Grams.
        /// </summary>
        public override ushort Amount { get; set; }
    }
}
