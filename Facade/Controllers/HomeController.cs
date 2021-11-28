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

        public HomeController(ICalculationFacade facade)
        {
            this._facade = facade;
        }

        [HttpGet]
        /// <summary>
        /// Renders the first "Index" page.
        /// </summary>
        public IActionResult Index([FromQuery] CalculationDto dto)
        {
            //dto = new CalculationDto
            //{
            //    NumbersToAdd = new[] { 4D, 8, 15, 16, 23, 42 },
            //    NumbersToMultiply = new[] { 6, 3.12037037037037 }
            //};

            var viewModel = new ResultViewModel
            {
                Value = this._facade.PrepareResult(dto)
            };

            return View(viewModel);
        }
    }
}
