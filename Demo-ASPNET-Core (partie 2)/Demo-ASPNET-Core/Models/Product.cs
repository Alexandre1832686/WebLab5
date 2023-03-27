using System.ComponentModel.DataAnnotations;

namespace Demo_ASPNET_Core.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Display(Name = "Code")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Le code est requis.")]
        [StringLength(15, ErrorMessage = "Le code ne doit pas avoir plus de {1} caractères.")]
        public string Code { get; set; } = string.Empty;

        [Display(Name = "Nom du produit")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Le nom est requis.")]
        [StringLength(70, ErrorMessage = "Le nom ne doit pas avoir plus de {1} caractères.")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Catégorie")]
        [Range(1, short.MaxValue, ErrorMessage = "La catégorie est requise.")]
        [Required(ErrorMessage = "La catégorie est requise.")]
        public int CategoryId { get; set; }

        [Display(Name = "Quantité en stock")]
        [Range(0, short.MaxValue, ErrorMessage = "La quantité en stock doit être positive.")]
        [Required(ErrorMessage = "La quantité en stock est requise.")]
        public short QuantityInStock { get; set; }

        /*
         Exemples d'utilisation de l'attribut DisplayFormat :

         Format "court" d'un DateTime : [DisplayFormat(ApplyFormatInEditMode=true, DataFormatString = "{0:d}")]
         Format monétaire d'un float : [DisplayFormat(DataFormatString = "{0:C0}")]
         */

        // Constructeur vide requis pour la désérialisation
        public Product()
        {
        }

        public Product(int id, string code, string name, int categoryId, short qtyInStock)
        {
            Id = id;
            Code = code;
            Name = name;
            CategoryId = categoryId;
            QuantityInStock = qtyInStock;
        }
    }
}
