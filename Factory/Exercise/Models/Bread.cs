using Factory.Exercise.Factories;
using System.ComponentModel.DataAnnotations;

namespace Factory.Exercise.Models
{
    public enum BreadType
    {
        [Display(Name = "Whole grains")]
        Low,
        [Display(Name = "Toast")]
        High
    }

    public sealed class Bread : IProduct
    {
        private readonly decimal _price;
        private readonly string _weight;
        private readonly string _name;

        public Bread(string type)
        {
            if (type == BreadType.Low.GetAttribute<DisplayAttribute>().Name)
            {
                _name = "Whole grains";
                _price = 1.65m;
                _weight = "750g";
            }
            else
            {
                _name = "Toast";
                _price = 1.2m;
                _weight = "1000g";
            }
        }
        public decimal GetPrice()
        {
            return _price;
        }

        public string GetName()
        {
            return _name;

        }

        public string GetWeight()
        {
            return _weight;
        }
    }
}
