using Facade.DTOs;
using Facade.Facade;
using Facade.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

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

        public HomeController(ILogger<HomeController> logger, ICalculationFacade facade)
        {
            this._logger = logger;
            this._facade = facade;
        }

        public IActionResult Index()
        {
            return default;
        }

        /// <summary>
        /// Renders the first "Index" page.
        /// </summary>
        public IActionResult Index<TAdd, TMultiply>(CalculationDto<TAdd, TMultiply> dto)
        {
            try
            {
                var viewModel = new ResultViewModel
                {
                    Value = this._facade.PrepareResult(dto)
                };

                return View(viewModel);
            }
            catch
            {
                return View();
            }
        }
    }
}
