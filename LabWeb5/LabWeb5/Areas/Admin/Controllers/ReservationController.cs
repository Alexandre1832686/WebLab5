using LabWeb5.Areas.Admin.DataAccessLayer.Factories;
using LabWeb5.Areas.Admin.DataAccessLayer;
using LabWeb5.Areas.Admin.Models;
using LabWeb5.Areas.Admin.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LabWeb5.ViewModels;

namespace LabWeb5.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReservationController : Controller
    {
        public IActionResult List()
        {
            DAL dal = new DAL();
            ReservationFactory facto = dal.ReservationFact;
            ReservationListVM vm = new ReservationListVM(facto.GetAll());
            return View(vm);
        }
    }
}
