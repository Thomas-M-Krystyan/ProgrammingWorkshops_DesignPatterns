using System.ComponentModel.DataAnnotations;
using Factory.Exercise.Factories;
using static Factory.Exercise.Models.ProductBase;

namespace Factory.Exercise.Models
{
    public enum MilkType
    {
        [Display(Name = "Low-Fat")]
        Low,
        [Display(Name = "High-Fat")]
        High
    }
    public sealed class Milk : Liquids
    {
        private readonly decimal _price;
        private readonly string _weight;
        private readonly string _name;

        public Milk(string type) : base(1,1.08M)
        {
            if (type == MilkType.Low.GetAttribute<DisplayAttribute>().Name)
            {
                _name = "Low-Fat 2%";
                _price = 1.08m;
                _weight = "1L";
            }
            else
            {
                _name = "High-Fat 3.5%";
                _price = 1.2m;
                _weight = "1L";
            }
        }
      
        public override string GetName() => _name;
      
    }
}
