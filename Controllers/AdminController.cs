using Microsoft.AspNetCore.Mvc;

namespace AuthLearnEmptyProject.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
