namespace Facade.DTOs
{
    /// <summary>
    /// The DTO to pass numbers to calculate.
    /// </summary>
    public sealed class CalculationDto
    {
        /// <summary>
        /// Gets or sets the numbers to add.
        /// </summary>
        public double[] NumbersToAdd { get; set; }

        /// <summary>
        /// Gets or sets the numbers to multiply.
        /// </summary>
        public double[] NumbersToMultiply { get; set; }
    }
}
