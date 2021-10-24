using Factory.Exercise.Abstractions;

namespace Factory.Exercise.Models
{
    public sealed class WholeGrainBread : ProductBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Bread"/> class.
        /// </summary>
        public WholeGrainBread() : base(0.750D, 1.65M)
	    {
        }

        /// <inheritdoc />
        public override string GetName() => "Whole Grain Bread";
    }

    public sealed class ToastBread : ProductBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ToastBread"/> class.
        /// </summary>
        public ToastBread() : base(1, 1.20M)
        {
        }

        /// <inheritdoc />
        public override string GetName() => "Toast Bread";
    }
}
