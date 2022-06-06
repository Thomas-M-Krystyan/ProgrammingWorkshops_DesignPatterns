using Command_Service;
using Command_Service.Commands.Implementations;
using Command_Service.Services.TextService.Implementations;
using Command_Service.Services.TextService.Interfaces;
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
        private readonly CommandsSubscriber _subscriber;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public HomeController(ILogger<HomeController> logger, ITextService textService)
        {
            // TODO: Most likely you want to either inject Commands here, or (better) some "Invoker" service

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
        /// <summary>
        /// Changes the background color of the text.
        /// </summary>
        /// <param name="dto">The command DTO model.</param>
        [HttpPost]
        public IActionResult UpdateFont(CommandDto dto)
        {
            CommandParametersDto domainDto = new()
            {
                ForegroundColor = dto.ForegroundColor,
                BackgroundColor = dto.BackgroundColor,
                IsFontBold = dto.IsFontBold
            };

            string style = this._subscriber.OnFontStyleUpdate(domainDto);

            return View(nameof(Index), new StyleViewModel(style));
        }
    }
}
