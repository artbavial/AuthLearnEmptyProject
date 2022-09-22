using Microsoft.AspNetCore.Mvc;

namespace AuthLearnEmptyProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
