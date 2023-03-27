using Demo_ASPNET_Core.Models;

namespace Demo_ASPNET_Core.Areas.Admin.ViewModels
{
    public class ProductListVM
    {
        private readonly Dictionary<int, Category> _categoryById = new Dictionary<int, Category>();

        public List<Category> Categories
        {
            get
            {
                return _categoryById.Values.ToList();
            }
        }

        public List<Product> Products { get; }

        public ProductListVM(List<Category> categories, List<Product> products)
        {
            foreach (Category category in categories)
            {
                _categoryById.Add(category.Id, category);
            }

            Products = products;
        }

        public string GetCategoryName(int id)
        {
            if (_categoryById.ContainsKey(id))
            {
                return _categoryById[id].Name;
            }

            return string.Empty;
        }
    }
}
