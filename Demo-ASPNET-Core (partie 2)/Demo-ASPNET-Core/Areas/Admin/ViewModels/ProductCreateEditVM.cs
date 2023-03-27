using Demo_ASPNET_Core.Models;

namespace Demo_ASPNET_Core.Areas.Admin.ViewModels
{
    public class ProductCreateEditVM
    {
        public Product Product { get; set; } = new Product();
        public List<Category>? Categories { get; set; }

        // Constructeur vide requis pour la désérialisation
        public ProductCreateEditVM()
        {
        }

        public ProductCreateEditVM(Product product, List<Category> categories)
        {
            Product = product;
            Categories = categories;
        }
    }
}
