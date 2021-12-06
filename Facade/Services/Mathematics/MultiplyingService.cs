using System;
using Facade.Services.Mathematics.Interfaces;
using Microsoft.Extensions.Logging;

namespace Facade.Services.Mathematics
{
    /// <summary>
    /// Multiplies numbers by each other.
    /// </summary>
    /// <seealso cref="ICalculate"/>
    public sealed class MultiplyingService : ICalculate
    {
        private readonly ILogger<MultiplyingService> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="MultiplyingService"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public MultiplyingService(ILogger<MultiplyingService> logger)
        {
            this._logger = logger;
        }

        /// <inheritdoc />
        public T Calculate<T>(params T[] numbers)
        {
            try
            {
                var result = numbers[0];

                for (var index = 1; index < numbers.Length; index++)
                {
                    result *= (dynamic)numbers[index];
                }

                return (T)Convert.ChangeType(result, typeof(T));
            }
            catch (Exception exception)
            {
                this._logger.LogError(exception.Message);

                return default;
            }
        }
    }
}
