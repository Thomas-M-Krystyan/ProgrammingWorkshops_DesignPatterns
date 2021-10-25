using Factory.Exercise.Abstractions;

namespace Factory.Exercise.Models
{
    public sealed class LowFatMilk : Liquids
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LowFatMilk"/> class.
        /// </summary>
        public LowFatMilk() : base(1, 1.08M)
        {
        }

        /// <inheritdoc />
        public override string GetName() => "Low-Fat Milk (2%)";
    }

    public sealed class HighFatMilk : Liquids
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HighFatMilk"/> class.
        /// </summary>
        public HighFatMilk() : base(1, 1.20M)
        {
        }

        /// <inheritdoc />
        public override string GetName() => "High-Fat Milk (3.5%)";
    }
}
