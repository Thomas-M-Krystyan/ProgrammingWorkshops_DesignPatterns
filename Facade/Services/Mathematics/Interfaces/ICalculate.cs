using System.Threading.Tasks;

namespace Facade.Services.Mathematics.Interfaces
{
    /// <summary>
    /// The interface for mathematics services.
    /// </summary>
    public interface ICalculate<S> where S : class, ICalculate<S>
    {
        /// <summary>
        /// Calculates the specified numbers.
        /// </summary>
        /// <typeparam name="T">The type of number.</typeparam>
        /// <param name="numbers">The numbers to be calculated.</param>
        /// <returns>The result of calculation.</returns>
        Task<T> Calculate<T>(params T[] numbers);
    }
}
