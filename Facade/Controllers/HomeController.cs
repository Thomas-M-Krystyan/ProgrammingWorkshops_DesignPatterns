using Microsoft.AspNetCore.Mvc;

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

            return View();
        }
    }
}
