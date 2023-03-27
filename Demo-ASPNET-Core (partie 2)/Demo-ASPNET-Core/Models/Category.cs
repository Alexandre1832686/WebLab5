namespace Demo_ASPNET_Core.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;

        // Constructeur vide requis pour la désérialisation
        public Category()
        {
        }

        public Category(int id, string name, string imagePath)
        {
            Id = id;
            Name = name;
            ImagePath = imagePath;
        }
    }
}
