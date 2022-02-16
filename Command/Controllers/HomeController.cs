using Command_Web.DTOs;
using Command_Web.ViewModels;
using Implementation.Commands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Command_Web.Controllers
{
    /// <summary>
    /// The main MVC Controller to display the Home page.
    /// </summary>
    /// <seealso cref="Controller" />
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public HomeController(ILogger<HomeController> logger)
        {
            this._logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(StyleViewModel viewModel)
        {
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult ChangeColor(CommandDto dto)
        {
            var command = new ChangeColorCommand();
            var result = command.Execute(dto.Color);

            return View(nameof(Index), new StyleViewModel(result));
        }
    }
}
