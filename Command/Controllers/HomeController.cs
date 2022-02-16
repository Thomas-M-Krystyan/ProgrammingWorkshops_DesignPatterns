using Command_Service.Commands.Implementations;
using Command_Service.Services.TextService.Implementations;
using Command_Web.DTOs;
using Command_Web.ViewModels;
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
        // TODO: Use logging in try-catch
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
            // ------------------------------------------------------------------------------
            // TODO #1: We should not use concrete implementation but interface of service!
            // TODO #2: Also, this is not a proper approach. Use Dependency Injection instead
            // TODO #3: Please, do not use command directly. Implement your version of "Invoker"
            // - check in materials code examples of Invoker class for Command Design Pattern

            var command = new ChangeFontColorCommand<ColorsEnum>(new TextService());
            // ------------------------------------------------------------------------------

            var result = command.Execute(dto.Color);

            return View(nameof(Index), new StyleViewModel(result));
        }

        // TODO: Implement new method ChangeWeight(xxx)

        // TODO: Implement new method ChangeBackground(xxx)
    }
}
