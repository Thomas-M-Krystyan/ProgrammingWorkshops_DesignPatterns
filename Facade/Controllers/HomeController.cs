using Microsoft.AspNetCore.Mvc;

namespace Facade.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // TODO: I want to have the result of calculation to be displayed in this view (Index.cshtml)

            return View();
        }
    }
}
