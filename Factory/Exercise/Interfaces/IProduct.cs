namespace Factory.Exercise.Interfaces
{
    /// <summary>
    /// The interface for all products.
    /// </summary>
    public interface IProduct
    {
        /// <summary>
        /// Gets the product name.
        /// </summary>
        string GetName();

        /// <summary>
        /// Gets the product unit (e.g. weight or volume).
        /// </summary>
        /// <returns></returns>
        string GetUnit();

        /// <summary>
        /// Gets the product unit (an alternative unit).
        /// </summary>
        string GetUnitAlt();

        /// <summary>
        /// Gets the product price (e.g. in euro).
        /// </summary>
        string GetPriceEur();
    }
}
