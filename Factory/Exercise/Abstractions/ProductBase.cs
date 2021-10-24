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
        private double _weightKg;

        /// <summary>
        /// Gets the product weight (in kilograms).
        /// </summary>
        public double WeightKg
        {
            get => this._weightKg;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The weight cannot be 0 or negative.");
                }

                this._weightKg = value;
            }
        }

        private decimal _priceEur;

        /// <summary>
        /// Gets the product price (in euro).
        /// </summary>
        public decimal PriceEur
        {
            get => this._priceEur;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The price cannot be negative.");
                }

                this._priceEur = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductBase"/> class.
        /// </summary>
        /// <param name="type">The product type.</param>
        /// <param name="weight">The product weight in KG.</param>
        /// <param name="price">The product price in EUR.</param>
        protected ProductBase(double weightKg, decimal priceEur)
        {
            this.WeightKg = weightKg;
            this.PriceEur = priceEur;
        }

        /// <inheritdoc />
        public abstract string GetName();

        /// <inheritdoc />
        public string GetWeightInKg()
        {
            return $"{this.WeightKg} kg";
        }

        /// <inheritdoc />
        public string GetWeightInLb()
        {
            const double KilogramsToPundsFactor = 2.20462262;

            return $"{(this.WeightKg * KilogramsToPundsFactor).ToString("N2", CultureInfo.InvariantCulture)} lb";
        }

        /// <inheritdoc />
        public string GetPriceInEur()
        {
            return $"€ {this.PriceEur.ToString("N2", CultureInfo.InvariantCulture)}";
        }
    }
}
