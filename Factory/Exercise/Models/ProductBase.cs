using Factory.Exercise.Factories;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Exercise.Models
{
    /// <summary>
    /// Class comments
    /// </summary>
    public abstract class ProductBase : IProduct
    {
        private double _weight;

        /// <summary>
        /// Property comments
        /// </summary>
        public double Weight
        {
            get => this._weight;
            private set
            {
                if(value <= 0)
                {
                    throw new ArgumentException("The weight cannot be 0 or negarive");
                }

                this._weight = Math.Round(value, 2);
            }
        }

        private decimal _price;
        
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
        /// Constructor comments
        /// </summary>
        /// <param name="unit"></param>
        /// <param name="price"></param>
        protected ProductBase(double unit, decimal price)
        {
            this.Weight = unit;
            this.Price = price;
        }


        public abstract string GetName();
        public string GetPrice()
        {
            return $"€ {this.Price.ToString(CultureInfo.InvariantCulture)}";
        }
        public virtual string GetWeight()
        {
            const double KilogramsToPundsFactor = 2.20462262;

            return $"{(this.Weight * KilogramsToPundsFactor).ToString("N2", CultureInfo.InvariantCulture)} lb";
        }

        public abstract class Liquids : ProductBase
        {
            protected Liquids(double unit, decimal price) : base(unit, price)
            {

            }
        }
    }
}
