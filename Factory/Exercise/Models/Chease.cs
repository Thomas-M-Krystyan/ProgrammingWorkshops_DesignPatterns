using Factory.Exercise.Factories;
using System.ComponentModel.DataAnnotations;

namespace Factory.Exercise.Models
{
    public enum CheaseType
    {
        [Display(Name = "Edamer")]
        Edamer,
        [Display(Name = "Gouda")]
        Gouda,
        [Display(Name = "Tilsner")]
        Tilsner,
        [Display(Name = "Salami")]
        Salami,
        [Display(Name = "Roqueford")]
        Roqueford,
        [Display(Name = "Camembert")]
        Camembert
    }

    public sealed class Chease : IProduct
    {
        private readonly decimal _price;
        private readonly string _weight;
        private readonly string _name;

        public Chease(string type)
        {

            if (type == CheaseType.Edamer.GetAttribute<DisplayAttribute>().Name)
            {
                _name = "Edamer";
                _price = 4.25m;
                _weight = "500g";
            }
            else
            {
                _name = "Gouda";
                _price = 4.75m;
                _weight = "500g";
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
