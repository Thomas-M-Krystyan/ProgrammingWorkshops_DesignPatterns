using Facade.DTOs;
using Facade.Facade;
using Facade.Services.Displays;
using Facade.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Facade.Controllers
{
    /// <summary>
    /// The main MVC Controller to display the Home page.
    /// </summary>
    /// <seealso cref="Controller" />
    public sealed class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICalculationFacade _facade;

        /// <summary>
        /// Injects dependencies for <see cref="HomeController"/>.
        /// </summary>
        public HomeController(ILogger<HomeController> logger, ICalculationFacade facade)
        {
            this._logger = logger;
            this._facade = facade;
        }

        /// <summary>
        /// Renders the main view with predefined calculation parameters.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            CalculationDto<decimal> dto = new()
            {
                NumbersToAddText = "4, 8, 15, 16, 23, 42",
                NumbersToMultiplyText = "6, 3.12037037037037",
                UseRoundUp = true,
                DisplayMode = DisplayModeEnums.WelcomeNewYear
            };

            return View(await PrepareViewModelFrom(dto));
        }

        /// <summary>
        /// Pass the <see cref="ResultViewModel"/> to the main view.
        /// </summary>
        [HttpPost]
        public IActionResult Index(ResultViewModel viewModel)
        {
            return View(viewModel);
        }

        /// <summary>
        /// Renders the first "Index" page with input-based calculation parameters.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Recalculate(CalculationDto<decimal> dto)
        {
            return View(nameof(Index), await PrepareViewModelFrom(dto));
        }

        /// <summary>
        /// Prepares the valid <see cref="ResultViewModel"/> from the given DTO.
        /// </summary>
        /// <typeparam name="T">The type of data used by DTO.</typeparam>
        /// <param name="dto">The DTO model.</param>
        /// <returns>The view model, ready to be used on a view.</returns>
        private async Task<ResultViewModel> PrepareViewModelFrom<T>(CalculationDto<T> dto)
        {
            ResultViewModel viewModel = new();

            try
            {
                viewModel.Value = await this._facade.PrepareResult(dto);
            }
            catch (Exception exception)
            {
                this._logger.LogError(exception.Message);

                viewModel.ErrorOccurred = true;
            }

            return viewModel;
        }
    }
}
