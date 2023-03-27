using Microsoft.AspNetCore.Mvc;

namespace Demo_ASPNET_Core.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
