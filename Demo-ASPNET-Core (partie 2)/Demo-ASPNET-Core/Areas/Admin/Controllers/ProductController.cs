using Demo_ASPNET_Core.Areas.Admin.ViewModels;
using Demo_ASPNET_Core.DataAccessLayer;
using Demo_ASPNET_Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo_ASPNET_Core.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        public IActionResult List()
        {
            DAL dal = new DAL();

            ProductListVM viewModel = new ProductListVM(
                dal.CategoryFact.GetAll(),
                dal.ProductFact.GetAll()); // new Product[0], // Pour tester l'affichage de "Aucun produit trouvé."

            return View(viewModel);
        }

        public IActionResult Create()
        {
            DAL dal = new DAL();

            ProductCreateEditVM viewModel = new ProductCreateEditVM(
                dal.ProductFact.CreateEmpty(),
                dal.CategoryFact.GetAll());

            return View("CreateEdit", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductCreateEditVM viewModel)
        {
            if (viewModel != null && viewModel.Product != null)
            {
                DAL dal = new DAL();

                Product? existingProduct = dal.ProductFact.GetByCode(viewModel.Product.Code);
                if (existingProduct != null)
                {
                    // Il est possible d'ajouter une erreur personnalisée.
                    // Le premier paramètre est la propriété touchée (à partir du viewModel ici)

                    ModelState.AddModelError("Product.Code", "Le code de produit existe déjà.");
                }

                if (!ModelState.IsValid)
                {
                    // Si le modèle n'est pas valide, on retourne à la vue CreateEdit où les messages seront affichés.
                    // Le ViewModèle reçu en POST n'est pas complet (seulement les info dans le <form> sont conservées),
                    // il faut donc réaffecter les Catégories.

                    viewModel.Categories = dal.CategoryFact.GetAll();
                    return View("CreateEdit", viewModel);
                }

                dal.ProductFact.Save(viewModel.Product);
            }

            return RedirectToAction("List");
        }

        public IActionResult Edit(int id)
        {
            if (id > 0)
            {
                DAL dal = new DAL();
                Product? product = dal.ProductFact.Get(id);

                if (product != null)
                {
                    ProductCreateEditVM viewModel = new ProductCreateEditVM(
                        product,
                        dal.CategoryFact.GetAll());

                    return View("CreateEdit", viewModel);
                }
            }

            return View("AdminMessage", new AdminMessageVM("L'identifiant du produit est introuvable."));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ProductCreateEditVM viewModel)
        {
            if (viewModel != null && viewModel.Product != null)
            {
                DAL dal = new DAL();

                Product? existingProduct = dal.ProductFact.GetByCode(viewModel.Product.Code);
                if (existingProduct != null && existingProduct.Id != viewModel.Product.Id)
                {
                    ModelState.AddModelError("Product.Code", "Le code de produit existe déjà.");
                }

                if (!ModelState.IsValid)
                {
                    viewModel.Categories = dal.CategoryFact.GetAll();
                    return View("CreateEdit", viewModel);
                }

                dal.ProductFact.Save(viewModel.Product);
            }

            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            if (id > 0)
            {
                DAL dal = new DAL();
                Product? product = dal.ProductFact.Get(id);

                if (product != null)
                {
                    ProductDeleteVM viewModel = new ProductDeleteVM(
                        product,
                        dal.CategoryFact.Get(product.CategoryId));

                    return View(viewModel);
                }
            }

            return View("AdminMessage", new AdminMessageVM("L'identifiant du produit est introuvable."));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            if (id > 0)
            {
                new DAL().ProductFact.Delete(id);
            }

            return RedirectToAction("List");
        }
    }
}
