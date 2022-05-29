namespace Builder.Exercise.Products.Interfaces
{
    /// <summary>
    /// This interface exposes only the name of the product. Particular components
    /// needs to be declared explicit on the product level (e.g., as properties).
    /// </summary>
    public interface IProduct
    {
        string Name { get; set; }
    }
}
