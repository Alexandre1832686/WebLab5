using Demo_ASPNET_Core.DataAccessLayer.Factories;

namespace Demo_ASPNET_Core.DataAccessLayer
{
    public class DAL
    {
        private ProductFactory? _productFact = null;
        private CategoryFactory? _categoryFact = null;

        public static string? ConnectionString { get; set; }

        public ProductFactory ProductFact
        {
            get
            {
                if (_productFact == null)
                {
                    _productFact = new ProductFactory();
                }

                return _productFact;
            }
        }

        public CategoryFactory CategoryFact
        {
            get
            {
                if (_categoryFact == null)
                {
                    _categoryFact = new CategoryFactory();
                }

                return _categoryFact;
            }
        }
    }
}
