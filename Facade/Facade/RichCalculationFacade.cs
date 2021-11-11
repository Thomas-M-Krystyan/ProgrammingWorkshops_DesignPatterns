using System;
using Facade.Services.Displays.Interfaces;
using Facade.Services.Mathematics.Interfaces;
using Microsoft.Extensions.Logging;

namespace Facade.Facade
{
    /// <summary>
    /// Process specific math operations and format them in a user-friendly way.
    /// </summary>
    public sealed class RichCalculationFacade
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

        /// <summary>
        /// Prepares the result.
        /// </summary>
        /// <typeparam name="T">The type of input data.</typeparam>
        /// <param name="numbers">The numbers to be calculated.</param>
        /// <returns>Formatted calculated result.</returns>
        public string PrepareResult<T>(params T[] numbers)
        {
            // TODO: Use this method in HomeController

            throw new NotImplementedException();
        }
    }
}
