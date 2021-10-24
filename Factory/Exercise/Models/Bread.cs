using Factory.Exercise.Abstractions;
using System;

namespace Factory.Exercise.Models
{
    public sealed class Bread : ProductBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Bread"/> class.
        /// </summary>
        public Bread(Enum type, double weightKg, decimal priceEur) : base(type, weightKg, priceEur)
	    {
        }

        /// <inheritdoc />
        public override string GetName()
        {
            return $"{this.Type} {nameof(Bread)}";
        }
    }
}
