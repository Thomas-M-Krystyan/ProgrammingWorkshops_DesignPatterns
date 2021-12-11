using Facade.DTOs;
using Facade.Services.Displays.Interfaces;
using Facade.Services.Mathematics;
using Facade.Services.Mathematics.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Facade.Facade
{
    /// <summary>
    /// Process specific math operations and format them in a user-friendly way.
    /// </summary>
    public sealed class RichCalculationFacade : ICalculationFacade
    {
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
        public RichCalculationFacade(ICalculate<AddingService> addingService, ICalculate<MultiplyingService> multiplyingService, IDisplay displayService)
        {
            this._addingService = addingService;
            this._multiplyingService = multiplyingService;
            this._displayService = displayService;
        }

        /// <inheritdoc />
        public async Task<string> PrepareResult<T>(CalculationDto<T> dto)
        {
            // Add
            T sum = await this._addingService.Calculate(dto.NumbersToAdd);

            // Multiply
            T[] numbersToMultiply = dto.NumbersToMultiply.Append(sum).ToArray();
            T product = await this._multiplyingService.Calculate(numbersToMultiply);

            if (dto.UseRoundUp)
            {
                product = (T)Convert.ChangeType(Math.Round(Decimal.Parse(product.ToString())), typeof(T));
            }

            // Display
            return await this._displayService.Enrich(product, dto.DisplayMode);
        }
    }
}
