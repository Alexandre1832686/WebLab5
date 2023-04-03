namespace LabWeb5.Areas.Admin.Models
{
    public class Reservation
    {
        public DateTime Date { get; set; }
        public string Nom { get; set; }
        public string Courriel { get; set; }
        public int ProduitId { get; set; }
        public int Nombre { get; set; }
        public int Id { get; set; }

        public Reservation()
        { }
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
