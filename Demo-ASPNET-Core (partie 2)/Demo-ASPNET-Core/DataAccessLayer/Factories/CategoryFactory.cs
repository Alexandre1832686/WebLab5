using Demo_ASPNET_Core.Models;
using MySql.Data.MySqlClient;

namespace Demo_ASPNET_Core.DataAccessLayer.Factories
{
    public class CategoryFactory
    {
        private Category CreateFromReader(MySqlDataReader mySqlDataReader)
        {
            int id = (int)mySqlDataReader["Id"];
            string name = mySqlDataReader["Name"].ToString() ?? string.Empty;
            string imagePath = mySqlDataReader["Image"].ToString() ?? string.Empty;

            return new Category(id, name, imagePath);
        }

        public Category CreateEmpty()
        {
            return new Category(0, string.Empty, string.Empty);
        }

        public List<Category> GetAll()
        {
            List<Category> categories = new List<Category>();
            MySqlConnection? mySqlCnn = null;
            MySqlDataReader? mySqlDataReader = null;

            try
            {
                mySqlCnn = new MySqlConnection(DAL.ConnectionString);
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "SELECT * FROM tp4_categories ORDER BY Name";

                mySqlDataReader = mySqlCmd.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    Category category = CreateFromReader(mySqlDataReader);
                    categories.Add(category);
                }
            }
            finally
            {
                mySqlDataReader?.Close();
                mySqlCnn?.Close();
            }

            return categories;
        }

        public Category? Get(int id)
        {
            Category? category = null;
            MySqlConnection? mySqlCnn = null;
            MySqlDataReader? mySqlDataReader = null;

            try
            {
                mySqlCnn = new MySqlConnection(DAL.ConnectionString);
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "SELECT * FROM tp4_categories WHERE Id = @Id";
                mySqlCmd.Parameters.AddWithValue("@Id", id);

                mySqlDataReader = mySqlCmd.ExecuteReader();
                if (mySqlDataReader.Read())
                {
                    category = CreateFromReader(mySqlDataReader);
                }
            }
            finally
            {
                mySqlDataReader?.Close();
                mySqlCnn?.Close();
            }

            return category;
        }
    }
}
