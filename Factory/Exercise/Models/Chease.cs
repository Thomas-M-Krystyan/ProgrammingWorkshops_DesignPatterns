using Factory.Exercise.Factories;

namespace Factory.Exercise.Models
{
    public enum CheaseType
    {
        Edamer,
        Gouda,
        Tilsner,
        Salami,
        Roqueford,
        Camembert
    }

    public sealed class Chease : IProduct
    {
        private CheaseType _type;
       

        public Chease(CheaseType type)
        {
            this._type = type;
        }

        public CheaseType GetCheaseType()
        {
            return _type;
        }

        public float GetPrice()
        {
            return 4.3f;
        }

        public string GetProductName()
        {
            return _type.ToString();

        }
        public float GetWeight()
        {
            return 2.5f;
        }
    }
}
