using LabWeb5.Areas.Admin.DataAccessLayer.Factories;

namespace LabWeb5.Areas.Admin.DataAccessLayer
{
    public class DAL
    {
        private ProductFactory? _productFact = null;
        private ReservationFactory? _reservationFact = null;


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

        public ReservationFactory ReservationFact
        {
            get
            {
                if (_reservationFact == null)
                {
                    _reservationFact = new ReservationFactory();
                }

                return _reservationFact;
            }
        }

    }
}
