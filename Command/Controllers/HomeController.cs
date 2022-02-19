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
            string result = this._subscriber.OnFontColorChange(dto.Color);

            return View(nameof(Index), new StyleViewModel(result));
        }

        // TODO: Implement new method ChangeWeight(xxx)

        // TODO: Implement new method ChangeBackground(xxx)
    }
}
