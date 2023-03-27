using Microsoft.AspNetCore.Mvc;

namespace LabWeb5.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
