namespace Builder.Exercise.Product.Implementations.Vehicles
{
    public sealed class Bike : BaseVehicle
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Bike"/> class.
        /// </summary>
        public Bike()
        {
            this.Wheels = 2;
            this.Doors = 0;
        }
    }
}
