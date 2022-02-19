using Command_Service.Services.TextService.Interfaces;
using Command_Service.Subscriber;
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
        private readonly ITextService _textService;
        private readonly ILogger<HomeController> _logger;
        private readonly CommandsSubscriber _subscriber;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="textService">The text service.</param>
        /// <param name="logger">The logger.</param>
        public HomeController(ITextService textService, ILogger<HomeController> logger)
        {
            // TODO: Most likely you want to either inject Commands here, or (better) some "Invoker" service
            this._textService = textService;
            this._logger = logger;

            this._subscriber = new(textService);
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="HomeController"/> class.
        /// </summary>
        ~HomeController()
        {
            this._subscriber?.Dispose();
        }

        // ------------
        // REST methods
        // ------------

        /// <summary>
        /// The main page with default view.
        /// </summary>
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// The main page with view reflecting user's choice (from input).
        /// </summary>
        [HttpPost]
        public IActionResult Index(StyleViewModel viewModel)
        {
            return View(viewModel);
        }

        /// <summary>
        /// Changes the foreground color of the text.
        /// </summary>
        /// <param name="dto">The command DTO model.</param>
        [HttpPost]
        public IActionResult ChangeColor(CommandDto dto)
        {
            string style = this._subscriber.OnFontColorChange(dto.Color);

            return View(nameof(Index), new StyleViewModel(style));
        }

        /// <summary>
        /// Changes the background color of the text.
        /// </summary>
        /// <param name="dto">The command DTO model.</param>
        [HttpPost]
        public IActionResult ChangeBackground(CommandDto dto)
        {
            string style = this._subscriber.OnFontBackgroundColorChange(dto.Color);

            return View(nameof(Index), new StyleViewModel(style));
        }

        /// <summary>
        /// Changes the font weight of the text.
        /// </summary>
        /// <param name="dto">The command DTO model.</param>
        [HttpPost]
        public IActionResult ChangeWeight(CommandDto dto)
        {
            string style = this._subscriber.OnFontWeightChange(dto.IsBold);

            return View(nameof(Index), new StyleViewModel(style));
        }
    }
}
