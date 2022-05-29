using Builder.Exercise.Components.Implementations.Models;
using Builder.Exercise.Components.Implementations.Models.Base;

namespace Builder.Exercise.Builder.Interfaces
{
    /// <summary>
    /// Provides methods suitable to create a food products.
    /// </summary>
    public interface IFoodBuilder
    {
        void InitializeProduct(string name, ushort weight);

        void AddSpices(params Spice[] spices);

        void AddHerbs(params Herb[] herbs);

        void AddIngredients(params BaseIngredient[] ingredients);
    }
}
