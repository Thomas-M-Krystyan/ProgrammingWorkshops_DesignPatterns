using Factory.Exercise.Abstractions;

namespace Factory.Exercise.Models
{
    public sealed class GoudaCheese : ProductBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GoudaCheese"/> class.
        /// </summary>
        public GoudaCheese() : base(0.500D, 4.75M)
        {
        }

        /// <inheritdoc />
        public override string GetName() => "Gouda Cheese";
    }

    public sealed class EdamerCheese : ProductBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EdamerCheese"/> class.
        /// </summary>
        public EdamerCheese() : base(0.500D, 4.25M)
        {
        }

        /// <inheritdoc />
        public override string GetName() => "Edamer Cheese";
    }
}
