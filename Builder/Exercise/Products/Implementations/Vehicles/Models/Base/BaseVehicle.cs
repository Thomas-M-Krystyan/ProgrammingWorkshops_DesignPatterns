using Builder.Exercise.Products.Implementations.Vehicles.Enums;
using Builder.Exercise.Products.Interfaces;

namespace Builder.Exercise.Products.Implementations.Vehicles.Models.Base
{
    /// <summary>
    /// Base class for vehicle products.
    /// </summary>
    /// <seealso cref="IProductComponentized" />
    public abstract class BaseVehicle : IProduct
    {
        public string Name { get; set; }

        public float WeightInKg { get; set; }

        public byte Wheels { get; protected set; }

        public byte Doors { get; protected set; }

        public ColorEnum Color { get; set; }
    }
}
