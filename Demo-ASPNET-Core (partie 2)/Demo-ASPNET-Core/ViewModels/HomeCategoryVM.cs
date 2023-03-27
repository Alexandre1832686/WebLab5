using Demo_ASPNET_Core.Models;

namespace Demo_ASPNET_Core.ViewModels
{
    public class HomeCategoryVM
    {
        public Category Category { get; }
        public List<Product> Products { get; }

        public HomeCategoryVM(Category category, List<Product> products)
        {
            Category = category;
            Products = products;
        }
    }
}
