using Facade.Services.Mathematics.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Facade.Services.Mathematics
{
    /// <summary>
    /// Adds numbers to each other.
    /// </summary>
    /// <seealso cref="ICalculate"/>
    public sealed class AddingService : ICalculate<AddingService>
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
        public async Task<T> Calculate<T>(params T[] numbers)
        {
            try
            {
                return await Task.Run(() =>
                {
                    T result = default;

                    foreach (T number in numbers)
                    {
                        result += (dynamic)number;
                    }

                    return (T)Convert.ChangeType(result, typeof(T));
                });
            }
            catch (Exception exception)
            {
                this._logger.LogError(exception.Message);

                return default;
            }
        }
    }
}
