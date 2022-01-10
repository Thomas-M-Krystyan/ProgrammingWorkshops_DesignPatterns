using Facade.Facade;
using Facade.Services.Displays;
using Facade.Services.Displays.Interfaces;
using Facade.Services.Mathematics;
using Facade.Services.Mathematics.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Facade.Controllers
{
    /// <summary>
    /// The main MVC Controller to display the Home page.
    /// </summary>
    /// <seealso cref="Controller" />
    public sealed class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICalculate _addingService;
        private readonly ICalculate _multiplyService;
        private readonly IDisplay _richTextService;

        public HomeController(ILogger<HomeController> logger,ICalculate addingService,ICalculate multiplyingService,IDisplay richTextService)
        {
            _logger = logger;
            _addingService = addingService;
            _multiplyService = multiplyingService;
            _richTextService = richTextService;

        }
        /// <summary>
        /// Renders the first "Homepage" page.
        /// </summary>
        public IActionResult Homepage()
        {
            // TODO: I want to have the result of calculation to be displayed in this view (Homepage.cshtml)
            //Get information for View
            //Prepare ViewModel and pass to the View 
            var result = GetResult();
            ViewData["Result"] = result;
            return View();// View with same name of the method will return
        }

        private string GetResult()
        {
            var richCalculationlogger = new Logger<RichCalculationFacade>(new LoggerFactory());
            double[] input = { 4.0, 8.0, 15.0, 16.0, 23.0, 42.0 };
            RichCalculationFacade cal =
                new RichCalculationFacade(richCalculationlogger, _addingService, _multiplyService, _richTextService);
            string result = cal.PrepareResult<double>(input);
            return result;
        }
    }
}
