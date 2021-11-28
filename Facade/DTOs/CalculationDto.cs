namespace Facade.DTOs
{
    /// <summary>
    /// The DTO to pass numbers to calculate.
    /// </summary>
    /// <typeparam name="TAdd">The type of numbers to add.</typeparam>
    /// <typeparam name="TMultiply">The type of numbers to multiply.</typeparam>
    public sealed class CalculationDto<TAdd, TMultiply>
    {
        /// <summary>
        /// Gets or sets the numbers to add.
        /// </summary>
        public TAdd[] NumbersToAdd { get; set; }

        /// <summary>
        /// Gets or sets the numbers to multiply.
        /// </summary>
        public TMultiply[] NumbersToMultiply { get; set; }
    }
}
