using Facade.DTOs;
using System.Threading.Tasks;

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
        /// <param name="dto">The DTO with numbers to be calculated.</param>
        /// <returns>Formatted calculated result.</returns>
        Task<string> PrepareResult<T>(CalculationDto<T> dto);
    }
}
