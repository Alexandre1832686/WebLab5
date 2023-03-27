using Microsoft.AspNetCore.Mvc;
using LabWeb5.Areas.Admin.DataAccessLayer;
using LabWeb5.Areas.Admin.DataAccessLayer.Factories;
using LabWeb5.Areas.Admin.ViewModels;
using LabWeb5.Areas.Admin.Models;

namespace LabWeb5.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuChoiceController : Controller
    {
        public IActionResult List()
        {
            DAL dal = new DAL();
            ProductFactory facto = dal.ProductFact;
            MenuListVM vm = new MenuListVM(facto.GetAll());
            return View(vm);
        }
    }
}
