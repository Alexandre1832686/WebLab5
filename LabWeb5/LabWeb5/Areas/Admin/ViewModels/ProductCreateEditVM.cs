using LabWeb5.Areas.Admin.Models;

namespace LabWeb5.Areas.Admin.ViewModels
{
    public class ProductCreateEditVM
    {
        public Produit Produit { get; set; } = new Produit();

        public ProductCreateEditVM()
        {
        }

        public ProductCreateEditVM(Produit product)
        {
            Produit = product;
        }
    }
}
