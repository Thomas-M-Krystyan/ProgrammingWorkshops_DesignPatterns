using Facade.DTOs;

namespace Facade.Facade
{
    /// <summary>
    /// Interface for calculation Facades.
    /// </summary>
    public interface ICalculationFacade
    {
        /// <summary>
        /// Prepares the result.
        /// </summary>
        /// <typeparam name="T">The type of input data.</typeparam>
        /// <param name="numbers">The numbers to be calculated.</param>
        /// <returns>Formatted calculated result.</returns>
        string PrepareResult<TAdd, TMultiply>(CalculationDto<TAdd, TMultiply> dto);
    }
}
