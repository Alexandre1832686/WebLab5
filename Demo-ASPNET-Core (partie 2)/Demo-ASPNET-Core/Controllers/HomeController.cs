using Demo_ASPNET_Core.DataAccessLayer;
using Demo_ASPNET_Core.Models;
using Demo_ASPNET_Core.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Demo_ASPNET_Core.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            DAL dal = new DAL();
            List<Category> categories = dal.CategoryFact.GetAll();

            return View(categories);
        }

        public IActionResult Category(int id)
        {
            if (id > 0)
            {
                DAL dal = new DAL();
                Category? category = dal.CategoryFact.Get(id);

                if (category != null)
                {
                    List<Product> products = dal.ProductFact.GetByCategory(category.Id);
                    HomeCategoryVM viewModel = new HomeCategoryVM(category, products);

                    return View(viewModel);
                }
            }

            return View("SiteMessage", new SiteMessageVM("L'identifiant de la catégorie est introuvable."));

            //return RedirectToAction("Index");
        }
    }
}