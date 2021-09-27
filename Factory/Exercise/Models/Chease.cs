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

    public sealed class Chease
    {
        private CheaseType _type;

        public Chease(CheaseType type)
        {
            this._type = type;
        }

        public CheaseType GetName()
        {
            return this._type;
        }

        public double GetWeight()
        {
            return 0.5f;
        }

        public decimal GetPrice()
        {
            return 5.45M;
        }
    }
}
