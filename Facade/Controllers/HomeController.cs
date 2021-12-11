using Facade.DTOs;
using Facade.Facade;
using Facade.Services.Displays;
using Facade.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Facade.Controllers
{
    /// <summary>
    /// The main MVC Controller to display the Home page.
    /// </summary>
    /// <seealso cref="Controller" />
    public sealed class HomeController : Controller
    {
        private readonly ICalculationFacade _facade;

        /// <summary>
        /// Injects dependencies for <see cref="HomeController"/>.
        /// </summary>
        public HomeController(ICalculationFacade facade)
        {
            this._facade = facade;
        }

        /// <summary>
        /// Renders the main view with predefined calculation parameters.
        /// </summary>
        [HttpGet]
        public IActionResult Index()
        {
            var dto = new CalculationDto<decimal>
            {
                NumbersToAddText = "4, 8, 15, 16, 23, 42",
                NumbersToMultiplyText = "6, 3.12037037037037",
                UseRoundUp = true,
                DisplayMode = DisplayModeEnums.WelcomeNewYear
            };

            return View(PrepareViewModelFrom(dto));
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
        public IActionResult Recalculate(CalculationDto<decimal> dto)
        {
            return View(nameof(Index), PrepareViewModelFrom(dto));
        }

        /// <summary>
        /// Prepares the valid <see cref="ResultViewModel"/> from the given DTO.
        /// </summary>
        /// <typeparam name="T">The type of data used by DTO.</typeparam>
        /// <param name="dto">The DTO model.</param>
        /// <returns>The view model, ready to be used on a view.</returns>
        private ResultViewModel PrepareViewModelFrom<T>(CalculationDto<T> dto)
        {
            var viewModel = new ResultViewModel();

            try
            {
                viewModel.Value = this._facade.PrepareResult(dto);
            }
            catch (Exception)
            {
                viewModel.ErrorOccurred = true;
            }

            return viewModel;
        }
    }
}
