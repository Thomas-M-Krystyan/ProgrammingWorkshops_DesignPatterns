using Facade.DTOs;
using Facade.Facade;
using Facade.ViewModels;
using Microsoft.AspNetCore.Mvc;

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
            var dto = new CalculationDto
            {
                NumbersToAdd = new double[] { 4, 8, 15, 16, 23, 42 },
                NumbersToMultiply = new[] { 6, 3.12037037037037 },
                UseRoundUp = true
            };

            var viewModel = new ResultViewModel
            {
                Value = this._facade.PrepareResult(dto)
            };

            return View(viewModel);
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
        public IActionResult Recalculate(CalculationDto dto)
        {
            var viewModel = new ResultViewModel
            {
                Value = this._facade.PrepareResult(dto)
            };

            return View(nameof(Index), viewModel);
        }
    }
}
