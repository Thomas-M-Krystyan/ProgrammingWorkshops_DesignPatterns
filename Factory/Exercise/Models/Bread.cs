using Factory.Exercise.Abstractions;
using Factory.Exercise.Enums;
using System;

namespace Factory.Exercise.Models
{
    public sealed class Bread : ProductBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Bread"/> class.
        /// </summary>
        public Bread(BreadTypes type, double weightKg, decimal priceEur) : base(type, weightKg, priceEur)
	    {
            ValidateParameters(type);
        }

        /// <inheritdoc />
        public override string GetName()
        {
            return $"{this.Type} {nameof(Bread)}";
        }

        /// <inheritdoc />
        protected override void ValidateParameters(params object[] parameters)
        {
            if (!Enum.IsDefined(typeof(BreadTypes), parameters[0].ToString()))
            {
                throw new ArgumentException($"Invalid {nameof(Bread)} type");
            }
        }
    }
}
