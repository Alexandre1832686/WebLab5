using Demo_ASPNET_Core.Models;

namespace Demo_ASPNET_Core.Areas.Admin.ViewModels
{
    public class ProductDeleteVM
    {
        public Product Product { get; }
        public Category? Category { get; }

        public string CategoryName
        {
            get
            {
                return Category?.Name ?? string.Empty;
            }
        }

        public ProductDeleteVM(Product product, Category? category)
        {
            Product = product;
            Category = category;
        }
    }
}
