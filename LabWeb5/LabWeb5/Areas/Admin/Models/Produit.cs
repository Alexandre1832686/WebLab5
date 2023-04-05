using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace LabWeb5.Areas.Admin.Models
{
    public class Produit
    {
        public int Id { get; set; }

        [Display(Name = "Nom")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "La description est requise.")]
        [StringLength(50, ErrorMessage = "Le code ne doit pas avoir plus de {1} caractères.")]
        public string Nom { get; set; } = string.Empty;



        public Produit()
        {

        }

        public Produit(string nom, int id)
        {
            Nom = nom;
            Id = id;
        }
    }
}
