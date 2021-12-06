using Facade.Facade;
using Facade.Services.Displays;
using Facade.Services.Mathematics;
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
        /// <summary>
        /// Renders the first "Index" page.
        /// </summary>
        public IActionResult Index()
        {
            // TODO: I want to have the result of calculation to be displayed in this view (Index.cshtml)

            var result = GetResult();
            ViewData["Result"] = result;
            return View();
        }

        private string GetResult()
        {
            var richCalculationlogger = new Logger<RichCalculationFacade>(new LoggerFactory());
            var addingServicelogger = new Logger<AddingService>(new LoggerFactory());
            var multiplyServicelogger = new Logger<MultiplyingService>(new LoggerFactory());
            var adddingService = new AddingService(addingServicelogger);
            var multiplyService = new MultiplyingService(multiplyServicelogger);
            var displayService = new RichTextService();
            double[] input = { 4.0, 8.0, 15.0, 16.0, 23.0, 42.0 };
            RichCalculationFacade cal =
                new RichCalculationFacade(richCalculationlogger, adddingService, multiplyService, displayService);
            string result = cal.PrepareResult(input);
            return result;
        }
    }
}
