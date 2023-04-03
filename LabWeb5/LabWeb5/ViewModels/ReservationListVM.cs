using LabWeb5.Areas.Admin.Models;

namespace LabWeb5.ViewModels
{
    public class ReservationListVM
    {
        public List<Reservation> reservation;

        public ReservationListVM(List<Reservation> res)
        {
            reservation = res;
        }
    }
}
