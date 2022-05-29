using Builder.Exercise.Components.Implementations.Models.Base;

namespace Builder.Exercise.Components.Implementations.Models
{
    public sealed class IngredientLiquid : BaseIngredient
    {
        /// <summary>
        /// Milliliters.
        /// </summary>
        public override ushort Amount { get; set; }
    }
}
