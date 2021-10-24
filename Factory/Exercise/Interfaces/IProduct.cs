namespace Factory.Exercise.Interfaces
{
    /// <summary>
    /// The interface for all products.
    /// </summary>
    public interface IProduct
    {
        /// <summary>
        /// Gets the product type.
        /// </summary>
        string GetTypeName();

        /// <summary>
        /// Gets the product name.
        /// </summary>
        string GetName();

        /// <summary>
        /// Gets the product weight (in kilograms).
        /// </summary>
        /// <returns></returns>
        string GetWeightInKg();

        /// <summary>
        /// Gets the product weight (in pounds).
        /// </summary>
        string GetWeightInLb();

        /// <summary>
        /// Gets the product price (in euro).
        /// </summary>
        string GetPriceInEur();
    }
}
