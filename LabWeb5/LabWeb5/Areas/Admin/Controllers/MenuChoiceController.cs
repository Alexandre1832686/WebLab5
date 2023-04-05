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

            ProductCreateEditVM viewModel = new ProductCreateEditVM(
                dal.ProductFact.CreateEmpty()
                );
            return View(viewModel);
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
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int id)
        {
            DAL dal = new DAL();
            ProductFactory facto = dal.ProductFact;
            facto.Delete(id);
            return RedirectToAction("List");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductCreateEditVM viewModel)
        {
            if (viewModel != null && viewModel.Produit != null)
            {
                DAL dal = new DAL();

                Produit? existingProduct = dal.ProductFact.GetByName(viewModel.Produit.Nom);
                if (existingProduct != null)
                {
                    // Il est possible d'ajouter une erreur personnalisée.
                    // Le premier paramètre est la propriété touchée (à partir du viewModel ici)

                    ModelState.AddModelError("Produit.Nom", "Le code de produit existe déjà.");
                }
                if (!ModelState.IsValid)
                {
                    // Si le modèle n'est pas valide, on retourne à la vue CreateEdit où les messages seront affichés.
                    // Le ViewModèle reçu en POST n'est pas complet (seulement les info dans le <form> sont conservées),
                    // il faut donc réaffecter les Catégories.

                    
                    return View(viewModel);
                }



                dal.ProductFact.Save(viewModel.Produit);
            }

            return RedirectToAction("List");
        }



    }
}
