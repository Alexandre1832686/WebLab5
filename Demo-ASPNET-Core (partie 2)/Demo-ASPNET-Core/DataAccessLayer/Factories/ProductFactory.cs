using Demo_ASPNET_Core.Models;
using MySql.Data.MySqlClient;

namespace Demo_ASPNET_Core.DataAccessLayer.Factories
{
    public class ProductFactory
    {
        private Product CreateFromReader(MySqlDataReader mySqlDataReader)
        {
            int id = (int)mySqlDataReader["Id"];
            string code = mySqlDataReader["Code"].ToString() ?? string.Empty;
            string name = mySqlDataReader["Name"].ToString() ?? string.Empty;
            int categoryId = (int)mySqlDataReader["CategoryId"];
            short qtyInStock = (short)mySqlDataReader["QuantityInStock"];

            return new Product(id, code, name, categoryId, qtyInStock);
        }

        public Product CreateEmpty()
        {
            return new Product(0, string.Empty, string.Empty, 0, 0);
        }

        public List<Product> GetAll()
        {
            List<Product> products = new List<Product>();
            MySqlConnection? mySqlCnn = null;
            MySqlDataReader? mySqlDataReader = null;

            try
            {
                mySqlCnn = new MySqlConnection(DAL.ConnectionString);
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "SELECT * FROM tp4_products ORDER BY Code";

                mySqlDataReader = mySqlCmd.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    Product product = CreateFromReader(mySqlDataReader);
                    products.Add(product);
                }
            }
            finally
            {
                mySqlDataReader?.Close();
                mySqlCnn?.Close();
            }

            return products;
        }

        public List<Product> GetByCategory(int categoryId)
        {
            List<Product> products = new List<Product>();
            MySqlConnection? mySqlCnn = null;
            MySqlDataReader? mySqlDataReader = null;

            try
            {
                mySqlCnn = new MySqlConnection(DAL.ConnectionString);
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "SELECT * FROM tp4_products WHERE CategoryId = @CatId ORDER BY Code";
                mySqlCmd.Parameters.AddWithValue("@CatId", categoryId);

                mySqlDataReader = mySqlCmd.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    Product product = CreateFromReader(mySqlDataReader);
                    products.Add(product);
                }
            }
            finally
            {
                mySqlDataReader?.Close();
                mySqlCnn?.Close();
            }

            return products;
        }

        public Product? Get(int id)
        {
            Product? product = null;
            MySqlConnection? mySqlCnn = null;
            MySqlDataReader? mySqlDataReader = null;

            try
            {
                mySqlCnn = new MySqlConnection(DAL.ConnectionString);
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "SELECT * FROM tp4_products WHERE Id = @Id";
                mySqlCmd.Parameters.AddWithValue("@Id", id);

                mySqlDataReader = mySqlCmd.ExecuteReader();
                if (mySqlDataReader.Read())
                {
                    product = CreateFromReader(mySqlDataReader);
                }
            }
            finally
            {
                mySqlDataReader?.Close();
                mySqlCnn?.Close();
            }

            return product;
        }

        public Product? GetByCode(string code)
        {
            Product? product = null;
            MySqlConnection? mySqlCnn = null;
            MySqlDataReader? mySqlDataReader = null;

            try
            {
                mySqlCnn = new MySqlConnection(DAL.ConnectionString);
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "SELECT * FROM tp4_products WHERE Code = @Code";
                mySqlCmd.Parameters.AddWithValue("@Code", code);

                mySqlDataReader = mySqlCmd.ExecuteReader();
                if (mySqlDataReader.Read())
                {
                    product = CreateFromReader(mySqlDataReader);
                }
            }
            finally
            {
                mySqlDataReader?.Close();
                mySqlCnn?.Close();
            }

            return product;
        }

        public void Save(Product product)
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
                    mySqlCmd.CommandText = "INSERT INTO tp4_products(Code, Name, CategoryId, Scale, Vendor, Description, QuantityInStock, BuyPrice, MSRP) " +
                                           "VALUES (@Code, @Name, @CategoryId, 1, '', '', @QuantityInStock, 0, 0)";
                }
                else
                {
                    mySqlCmd.CommandText = "UPDATE tp4_products " +
                                           "SET Code=@Code, Name=@Name, CategoryId=@CategoryId, QuantityInStock=@QuantityInStock " +
                                           "WHERE Id=@Id";

                    mySqlCmd.Parameters.AddWithValue("@Id", product.Id);
                }

                mySqlCmd.Parameters.AddWithValue("@Code", product.Code?.Trim());
                mySqlCmd.Parameters.AddWithValue("@Name", product.Name?.Trim());
                mySqlCmd.Parameters.AddWithValue("@CategoryId", product.CategoryId);
                mySqlCmd.Parameters.AddWithValue("@QuantityInStock", product.QuantityInStock);

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
                mySqlCmd.CommandText = "DELETE FROM tp4_products WHERE Id=@Id";
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
