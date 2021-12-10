using Facade.DTOs;
using Facade.Services.Displays.Interfaces;
using Facade.Services.Mathematics;
using Facade.Services.Mathematics.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace Facade.Facade
{
    /// <summary>
    /// Process specific math operations and format them in a user-friendly way.
    /// </summary>
    public sealed class RichCalculationFacade : ICalculationFacade
    {
        private readonly ILogger<RichCalculationFacade> _logger;
        private readonly ICalculate<AddingService> _addingService;
        private readonly ICalculate<MultiplyingService> _multiplyingService;
        private readonly IDisplay _displayService;

        /// <summary>
        /// Initializes a new instance of the <see cref="RichCalculationFacade"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="addingService">The adding service.</param>
        /// <param name="multiplyingService">The multiplying service.</param>
        /// <param name="displayService">The display service.</param>
        public RichCalculationFacade(ILogger<RichCalculationFacade> logger, ICalculate<AddingService> addingService,
                                     ICalculate<MultiplyingService> multiplyingService, IDisplay displayService)
        {
            this._logger = logger;
            this._addingService = addingService;
            this._multiplyingService = multiplyingService;
            this._displayService = displayService;
        }

        /// <inheritdoc />
        public string PrepareResult(CalculationDto dto)
        {
            try
            {
                // Add
                var sum = this._addingService.Calculate(dto.NumbersToAdd);

                // Multiply
                var numbersToMultiply = dto.NumbersToMultiply.Append(sum).ToArray();
                var product = this._multiplyingService.Calculate(numbersToMultiply);

                if (dto.UseRoundUp)
                {
                    product = Math.Round(product);
                }
                
                // Display
                return this._displayService.Enrich(product);
            }
            catch (Exception exception)
            {
                this._logger.LogError(exception.Message);

                return $"Failed to process numbers";
            }
        }
    }
}
