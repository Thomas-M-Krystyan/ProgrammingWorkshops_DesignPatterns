﻿using Factory.Exercise.Interfaces;
using System;

namespace Factory.Exercise.Abstractions
{
    /// <summary>
    /// The base class for all products.
    /// </summary>
    /// <seealso cref="IProduct" />
    public abstract class ProductBase : IProduct
    {
        /// <summary>
        /// Gets the product type.
        /// </summary>
        public Enum Type { get; }

        /// <summary>
        /// Gets the product weight (in kilograms).
        /// </summary>
        public double WeightKg { get; }

        /// <summary>
        /// Gets the product price (in euro).
        /// </summary>
        public decimal PriceEur { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductBase"/> class.
        /// </summary>
        /// <param name="type">The product type.</param>
        /// <param name="weight">The product weight in KG.</param>
        /// <param name="price">The product price in EUR.</param>
        protected ProductBase(Enum type, double weightKg, decimal priceEur)
        {
            this.Type = type;
            this.WeightKg = weightKg;
            this.PriceEur = priceEur;
        }

        /// <inheritdoc />
        public new string GetType()
        {
            return this.Type.ToString();  // NOTE: Get enum name
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

            return $"{String.Format("{0:0.00}", this.WeightKg * KilogramsToPundsFactor)} lb";
        }

        /// <inheritdoc />
        public string GetPriceInEur()
        {
            return $"€ {String.Format("{0:0.00}", this.PriceEur)}";
        }

        /// <summary>
        /// Validates the model parameters.
        /// </summary>
        protected virtual void ValidateParameters<T>(T type, double weightKg, decimal priceEur) where T : Enum
        {
            // Type
            if (!Enum.IsDefined(typeof(T), type.ToString()))
            {
                throw new ArgumentException($"Invalid product type.");
            }

            // Weight
            if (weightKg <= 0)
            {
                throw new ArgumentException("The weight cannot be 0 or negative.");
            }

            // Price
            if (priceEur < 0)
            {
                throw new ArgumentException("The price cannot be negative.");
            }
        }
    }
}
