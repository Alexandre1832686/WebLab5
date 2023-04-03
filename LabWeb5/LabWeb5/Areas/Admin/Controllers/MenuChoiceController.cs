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

        [Area("Admin")]
        public IActionResult Edit(int id)
        {
            DAL dal = new DAL();
            ProductFactory facto = dal.ProductFact;
            return View(facto.Get(id));
        }
        [Area("Admin")]
        public IActionResult Create()
        {
            DAL dal = new DAL();
            ProductFactory facto = dal.ProductFact;
            return View(facto.CreateEmpty());
        }
        [Area("Admin")]
        public IActionResult Delete(int id)
        {
            DAL dal = new DAL();
            ProductFactory p = dal.ProductFact;
            return View(p.Get(id));
        }

        [HttpPost]
        public IActionResult Edit(Produit p)
        {
            DAL dal = new DAL();
            ProductFactory facto = dal.ProductFact;
            facto.Save(p);
           return RedirectToAction("List");
        }
        [HttpPost]
        public IActionResult DeletePost(int id)
        {
            DAL dal = new DAL();
            ProductFactory facto = dal.ProductFact;
            facto.Delete(id);
            return RedirectToAction("List");
        }



    }
}
