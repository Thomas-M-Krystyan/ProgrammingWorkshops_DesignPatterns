using System;
using System.Linq;
using Facade.Services.Mathematics.Interfaces;
using Microsoft.Extensions.Logging;

namespace Facade.Services.Mathematics
{
    /// <summary>
    /// Adds numbers to each other.
    /// </summary>
    /// <seealso cref="ICalculate"/>
    public sealed class AddingService : ICalculate
    {
        private readonly ILogger<AddingService> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddingService"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public AddingService(ILogger<AddingService> logger)
        {
            this._logger = logger;
        }

        /// <inheritdoc />
        public T Calculate<T>(params T[] numbers)
        {
            try
            {
                var result = default(T);

                // NOTE: LINQ version of foreach loop adding <T> numbers to the "result"
                result = numbers.Cast<dynamic>().Aggregate(result, (current, number) => (T)(current + number));

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
