using Facade.DTOs;
using Facade.Services.Displays.Interfaces;
using Facade.Services.Mathematics.Interfaces;
using Microsoft.Extensions.Logging;
using System;

namespace Facade.Facade
{
    /// <summary>
    /// Process specific math operations and format them in a user-friendly way.
    /// </summary>
    public sealed class RichCalculationFacade : ICalculationFacade
    {
        private readonly ILogger<RichCalculationFacade> _logger;
        private readonly ICalculate _addingService;
        private readonly ICalculate _multiplyingService;
        private readonly IDisplay _displayService;

        /// <summary>
        /// Initializes a new instance of the <see cref="RichCalculationFacade"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="addingService">The adding service.</param>
        /// <param name="multiplyingService">The multiplying service.</param>
        /// <param name="displayService">The display service.</param>
        public RichCalculationFacade(ILogger<RichCalculationFacade> logger, ICalculate addingService,
                                     ICalculate multiplyingService, IDisplay displayService)
        {
            this._logger = logger;
            this._addingService = addingService;
            this._multiplyingService = multiplyingService;
            this._displayService = displayService;
        }

        /// <inheritdoc />
        public string PrepareResult<TAdd, TMultiply>(CalculationDto<TAdd, TMultiply> dto)
        {
            try
            {
                var addedNumbers = this._addingService.Calculate(dto.NumbersToAdd);
                var multipliedNumbers = this._multiplyingService.Calculate(dto.NumbersToMultiply);
                
                return this._displayService.Enrich(multipliedNumbers);
            }
            catch (Exception exception)
            {
                this._logger.LogError(exception.Message);

                return $"Failed to process numbers";
            }
        }
    }
}
