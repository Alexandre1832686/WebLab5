using LabWeb5.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace LabWeb5.Controllers
{
    public class ReservationController : Controller
    {
        public IActionResult Details(Reservation r)
        {
            return View(r);
        }
    }
}
