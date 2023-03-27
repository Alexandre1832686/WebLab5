using LabWeb5.Areas.Admin.Models;
namespace LabWeb5.Areas.Admin.ViewModels
{
    public class MenuListVM
    {
        public List<Produit> Produits;
        
        public MenuListVM(List<Produit> produits)
        {
            Produits = produits;
        }
    }
}
