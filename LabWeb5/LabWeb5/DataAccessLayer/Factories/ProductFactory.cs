using LabWeb5.Areas.Admin.Models;
using MySql.Data.MySqlClient;

namespace LabWeb5.Areas.Admin.DataAccessLayer.Factories
{
    public class ProductFactory
    {

        private Produit CreateFromReader(MySqlDataReader mySqlDataReader)
        {
            
            string name = mySqlDataReader["Description"].ToString() ?? string.Empty;
            int id = Convert.ToInt32(mySqlDataReader["Id"]);

            return new Produit(name,id);
        }
        public Produit CreateEmpty()
        {
            return new Produit("",0);
        }

        public List<Produit> GetAll()
        {
            List<Produit> Produits = new List<Produit>();
            MySqlConnection? mySqlCnn = null;
            MySqlDataReader? mySqlDataReader = null;

            try
            {
                mySqlCnn = new MySqlConnection(DAL.ConnectionString);
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "SELECT * FROM tp5_menuchoices";

                mySqlDataReader = mySqlCmd.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    Produit Produit = CreateFromReader(mySqlDataReader);
                    Produits.Add(Produit);
                }
            }
            finally
            {
                mySqlDataReader?.Close();
                mySqlCnn?.Close();
            }

            return Produits;
        }

        public Produit? Get(int id)
        {
            Produit? Produit = null;
            MySqlConnection? mySqlCnn = null;
            MySqlDataReader? mySqlDataReader = null;

            try
            {
                mySqlCnn = new MySqlConnection(DAL.ConnectionString);
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "SELECT * FROM tp5_menuchoices WHERE Id = @Id";
                mySqlCmd.Parameters.AddWithValue("@Id", id);

                mySqlDataReader = mySqlCmd.ExecuteReader();
                if (mySqlDataReader.Read())
                {
                    Produit = CreateFromReader(mySqlDataReader);
                }
            }
            finally
            {
                mySqlDataReader?.Close();
                mySqlCnn?.Close();
            }

            return Produit;
        }

        public void Save(Produit product)
        {
            MySqlConnection? mySqlCnn = null;

            try
            {
                mySqlCnn = new MySqlConnection(DAL.ConnectionString);
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                if (product.Id == 0)
                {
                    // On sait que c'est un nouveau produit avec Id == 0,
                    // car c'est ce que nous avons affecter dans la fonction CreateEmpty().
                    mySqlCmd.CommandText = "INSERT INTO tp5_menuchoices(Description)" +
                                            "VALUES (@Nom)";
                }
                else
                {
                    mySqlCmd.CommandText = "UPDATE tp5_menuchoices " +
                                            "SET Description=@Nom " +
                                            "WHERE Id=@Id";

                    mySqlCmd.Parameters.AddWithValue("@Id", product.Id);
                }

                
                mySqlCmd.Parameters.AddWithValue("@Nom", product.Nom?.Trim());
               

                mySqlCmd.ExecuteNonQuery();

                if (product.Id == 0)
                {
                    // Si c'était un nouveau produit (requête INSERT),
                    // nous affectons le nouvel Id de l'instance au cas où il serait utilisé dans le code appelant.
                    product.Id = (int)mySqlCmd.LastInsertedId;
                }
            }
            finally
            {
                mySqlCnn?.Close();
            }
        }


        public void Delete(int id)
        {
            MySqlConnection? mySqlCnn = null;

            try
            {
                mySqlCnn = new MySqlConnection(DAL.ConnectionString);
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "DELETE FROM tp5_menuchoices WHERE Id=@Id";
                mySqlCmd.Parameters.AddWithValue("@Id", id);
                mySqlCmd.ExecuteNonQuery();
            }
            finally
            {
                mySqlCnn?.Close();
            }
        }
    }
}
