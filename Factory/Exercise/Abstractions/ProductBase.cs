using Factory.Exercise.Interfaces;
using System;
using System.Globalization;

namespace Factory.Exercise.Abstractions
{
    /// <summary>
    /// The base class for all products.
    /// </summary>
    /// <seealso cref="IProduct" />
    public abstract class ProductBase : IProduct
    {
        private double _unit;

        /// <summary>
        /// Gets the product unit.
        /// </summary>
        public double Unit
        {
            get => this._unit;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The weight cannot be 0 or negative.");
                }

                this._unit = Math.Round(value, 2);
            }
        }

        private decimal _price;

        /// <summary>
        /// Gets the product price.
        /// </summary>
        public decimal Price
        {
            get => this._price;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The price cannot be negative.");
                }

                this._price = Math.Round(value, 2);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductBase"/> class.
        /// </summary>
        /// <param name="unit">The product unit (e.g. weight or volume).</param>
        /// <param name="price">The product price.</param>
        protected ProductBase(double unit, decimal price)
        {
            this.Unit = unit;
            this.Price = price;
        }

        /// <inheritdoc />
        public abstract string GetName();

        /// <inheritdoc />
        public virtual string GetUnit()
        {
            return $"{this.Unit.ToString(CultureInfo.InvariantCulture)} kg";
        }

        /// <inheritdoc />
        public string GetUnitAlt()
        {
            const double KilogramsToPundsFactor = 2.20462262;

            return $"{(this.Unit * KilogramsToPundsFactor).ToString("N2", CultureInfo.InvariantCulture)} lb";
        }

        /// <inheritdoc />
        public string GetPriceEur()
        {
            return $"€ {this.Price.ToString(CultureInfo.InvariantCulture)}";
        }
    }

    /// <summary>
    /// The base class for all liquids to display units as volumes.
    /// </summary>
    /// <seealso cref="ProductBase" />
    public abstract class Liquids : ProductBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Liquids"/> class.
        /// </summary>
        /// <param name="unit">The product unit (e.g. weight or volume).</param>
        /// <param name="price">The product price.</param>
        protected Liquids(double unit, decimal price) : base(unit, price)
        {
        }

        /// <inheritdoc />
        public override string GetUnit()
        {
            return $"{this.Unit.ToString(CultureInfo.InvariantCulture)} l";
        }
    }
}
