using LabWeb5.Areas.Admin.DataAccessLayer;
using LabWeb5.Areas.Admin.DataAccessLayer.Factories;
using LabWeb5.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace LabWeb5.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Reservation r)
        {
            DAL dal = new DAL();
            ReservationFactory facto = dal.ReservationFact;
            facto.Save(r);

            return RedirectToAction("Details", "Reservation", r);
        }
        
    }
}
