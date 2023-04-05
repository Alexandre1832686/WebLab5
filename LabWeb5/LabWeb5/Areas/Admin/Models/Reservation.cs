using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Xml.Linq;

namespace LabWeb5.Areas.Admin.Models
{
    public class Reservation
    {

        public DateTime Date { get; set; }


        [Display(Name = "Nom")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "La description est requise.")]
        [StringLength(50, ErrorMessage = "Le Nom ne doit pas avoir plus de {1} caractères.")]
        public string Nom { get; set; }


        [Display(Name = "Courriel")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Le Courriel est requis.")]
        [StringLength(75, ErrorMessage = "Le Courriel ne doit pas avoir plus de {1} caractères.")]
        public string Courriel { get; set; }

        [Display(Name = "Menu")]
        [Range(1, short.MaxValue, ErrorMessage = "Le Menu est requis.")]
        [Required(ErrorMessage = "Le Menu est requis.")]
        public int ProduitId { get; set; }


        [Display(Name = "Nombre")]
        [Range(0, short.MaxValue, ErrorMessage = "La quantité en stock doit être positive.")]
        [Required(ErrorMessage = "Le nombre est requis.")]
        public int Nombre { get; set; }


        public int Id { get; set; }

        public Reservation()
        { 
        }
        public Reservation(DateTime date, string nom,string courriel, int produitId, int nbPersonnes, int id)
        {
            Date = DateTime.Now;
            Nom = nom;
            Courriel = courriel;
            ProduitId = produitId;
            Nombre = nbPersonnes;
            Id = id;
        }
    }
}
