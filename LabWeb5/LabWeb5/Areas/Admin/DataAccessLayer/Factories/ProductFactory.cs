using LabWeb5.Areas.Admin.Models;
using MySql.Data.MySqlClient;

namespace LabWeb5.Areas.Admin.DataAccessLayer.Factories
{
    public class ProductFactory
    {

        private Produit CreateFromReader(MySqlDataReader mySqlDataReader)
        {
            
            string name = mySqlDataReader["Description"].ToString() ?? string.Empty;
            

            return new Produit(name);
        }
        public Produit CreateEmpty()
        {
            return new Produit("");
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

        //public List<Produit> GetByCategory(int categoryId)
        //{
        //    List<Produit> Produits = new List<Produit>();
        //    MySqlConnection? mySqlCnn = null;
        //    MySqlDataReader? mySqlDataReader = null;

        //    try
        //    {
        //        mySqlCnn = new MySqlConnection(DAL.ConnectionString);
        //        mySqlCnn.Open();

        //        MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
        //        mySqlCmd.CommandText = "SELECT * FROM tp4_Produits WHERE CategoryId = @CatId ORDER BY Code";
        //        mySqlCmd.Parameters.AddWithValue("@CatId", categoryId);

        //        mySqlDataReader = mySqlCmd.ExecuteReader();
        //        while (mySqlDataReader.Read())
        //        {
        //            Produit Produit = CreateFromReader(mySqlDataReader);
        //            Produits.Add(Produit);
        //        }
        //    }
        //    finally
        //    {
        //        mySqlDataReader?.Close();
        //        mySqlCnn?.Close();
        //    }

        //    return Produits;
        //}

        //public Produit? Get(int id)
        //{
        //    Produit? Produit = null;
        //    MySqlConnection? mySqlCnn = null;
        //    MySqlDataReader? mySqlDataReader = null;

        //    try
        //    {
        //        mySqlCnn = new MySqlConnection(DAL.ConnectionString);
        //        mySqlCnn.Open();

        //        MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
        //        mySqlCmd.CommandText = "SELECT * FROM tp4_Produits WHERE Id = @Id";
        //        mySqlCmd.Parameters.AddWithValue("@Id", id);

        //        mySqlDataReader = mySqlCmd.ExecuteReader();
        //        if (mySqlDataReader.Read())
        //        {
        //            Produit = CreateFromReader(mySqlDataReader);
        //        }
        //    }
        //    finally
        //    {
        //        mySqlDataReader?.Close();
        //        mySqlCnn?.Close();
        //    }

        //    return Produit;
        //}

        //public Produit? GetByCode(string code)
        //{
        //    Produit? Produit = null;
        //    MySqlConnection? mySqlCnn = null;
        //    MySqlDataReader? mySqlDataReader = null;

        //    try
        //    {
        //        mySqlCnn = new MySqlConnection(DAL.ConnectionString);
        //        mySqlCnn.Open();

        //        MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
        //        mySqlCmd.CommandText = "SELECT * FROM tp4_Produits WHERE Code = @Code";
        //        mySqlCmd.Parameters.AddWithValue("@Code", code);

        //        mySqlDataReader = mySqlCmd.ExecuteReader();
        //        if (mySqlDataReader.Read())
        //        {
        //            Produit = CreateFromReader(mySqlDataReader);
        //        }
        //    }
        //    finally
        //    {
        //        mySqlDataReader?.Close();
        //        mySqlCnn?.Close();
        //    }

        //    return Produit;
        //}

        //public void Save(Produit Produit)
        //{
        //    MySqlConnection? mySqlCnn = null;

        //    try
        //    {
        //        mySqlCnn = new MySqlConnection(DAL.ConnectionString);
        //        mySqlCnn.Open();

        //        MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
        //        if (Produit.Id == 0)
        //        {
        //            // On sait que c'est un nouveau produit avec Id == 0,
        //            // car c'est ce que nous avons affecter dans la fonction CreateEmpty().
        //            mySqlCmd.CommandText = "INSERT INTO tp4_Produits(Code, Name, CategoryId, Scale, Vendor, Description, QuantityInStock, BuyPrice, MSRP) " +
        //                                   "VALUES (@Code, @Name, @CategoryId, 1, '', '', @QuantityInStock, 0, 0)";
        //        }
        //        else
        //        {
        //            mySqlCmd.CommandText = "UPDATE tp4_Produits " +
        //                                   "SET Code=@Code, Name=@Name, CategoryId=@CategoryId, QuantityInStock=@QuantityInStock " +
        //                                   "WHERE Id=@Id";

        //            mySqlCmd.Parameters.AddWithValue("@Id", Produit.Id);
        //        }

        //        mySqlCmd.Parameters.AddWithValue("@Code", Produit.Code?.Trim());
        //        mySqlCmd.Parameters.AddWithValue("@Name", Produit.Name?.Trim());
        //        mySqlCmd.Parameters.AddWithValue("@CategoryId", Produit.CategoryId);
        //        mySqlCmd.Parameters.AddWithValue("@QuantityInStock", Produit.QuantityInStock);

        //        mySqlCmd.ExecuteNonQuery();

        //        if (Produit.Id == 0)
        //        {
        //            // Si c'était un nouveau produit (requête INSERT),
        //            // nous affectons le nouvel Id de l'instance au cas où il serait utilisé dans le code appelant.
        //            Produit.Id = (int)mySqlCmd.LastInsertedId;
        //        }
        //    }
        //    finally
        //    {
        //        mySqlCnn?.Close();
        //    }
        //}

        //public void Delete(int id)
        //{
        //    MySqlConnection? mySqlCnn = null;

        //    try
        //    {
        //        mySqlCnn = new MySqlConnection(DAL.ConnectionString);
        //        mySqlCnn.Open();

        //        MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
        //        mySqlCmd.CommandText = "DELETE FROM tp4_Produits WHERE Id=@Id";
        //        mySqlCmd.Parameters.AddWithValue("@Id", id);
        //        mySqlCmd.ExecuteNonQuery();
        //    }
        //    finally
        //    {
        //        mySqlCnn?.Close();
        //    }
        //}
    }
}
