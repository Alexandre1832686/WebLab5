using LabWeb5.Areas.Admin.Models;
using MySql.Data.MySqlClient;
using System.Xml.Linq;

namespace LabWeb5.Areas.Admin.DataAccessLayer.Factories
{
    public class ReservationFactory
    {
        private Reservation CreateFromReader(MySqlDataReader mySqlDataReader)
        {
            int id = Convert.ToInt32(mySqlDataReader["Id"]);
            DateTime date = Convert.ToDateTime(mySqlDataReader["DateReservation"]);
            string name = mySqlDataReader["Nom"].ToString() ?? string.Empty;
            string courriel = mySqlDataReader["Courriel"].ToString() ?? string.Empty;
            int idProduit = Convert.ToInt32(mySqlDataReader["MenuChoiceId"]);
            int nbPersonnes = Convert.ToInt32(mySqlDataReader["NbPersonne"]);

            return new Reservation(date,name,courriel, idProduit,nbPersonnes,id);
        }
        public Reservation CreateEmpty()
        {
            return new Reservation(DateTime.MinValue, "","", 0, 0,0);
        }

        public List<Reservation> GetAll()
        {
            List<Reservation> reservations = new List<Reservation>();
            MySqlConnection? mySqlCnn = null;
            MySqlDataReader? mySqlDataReader = null;

            try
            {
                mySqlCnn = new MySqlConnection(DAL.ConnectionString);
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "SELECT * FROM tp5_reservations";

                mySqlDataReader = mySqlCmd.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    Reservation res = CreateFromReader(mySqlDataReader);
                    reservations.Add(res);
                }
            }
            finally
            {
                mySqlDataReader?.Close();
                mySqlCnn?.Close();
            }

            return reservations;
        }
        public void Save(Reservation res)
        {
            MySqlConnection? mySqlCnn = null;

            try
            {
                mySqlCnn = new MySqlConnection(DAL.ConnectionString);
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                if (res.Id == 0)
                {
                    // On sait que c'est un nouveau produit avec Id == 0,
                    // car c'est ce que nous avons affecter dans la fonction CreateEmpty().
                    mySqlCmd.CommandText = "INSERT INTO tp5_reservations(Nom, Courriel, DateReservation,MenuChoiceId,NbPersonne) VALUES (@Nom,@Courriel,@DateReservation,@MenuChoiceId,@NbPersonne)";
                }
                else
                {
                    mySqlCmd.CommandText = "UPDATE tp5_reservations " +
                                            "SET Nom=@Nom, " +
                                            "Courriel=@Courriel, " +
                                            "DateReservation=@DateReservation, " +
                                            "MenuChoiceId=@MenuChoiceId " +
                                            
                                            "WHERE Id=@Id";

                    mySqlCmd.Parameters.AddWithValue("@Id", res.Id);
                }


                mySqlCmd.Parameters.AddWithValue("@Nom", res.Nom?.Trim());
                mySqlCmd.Parameters.AddWithValue("@Courriel", res.Courriel?.Trim());
                mySqlCmd.Parameters.AddWithValue("@DateReservation", res.Date);
                mySqlCmd.Parameters.AddWithValue("@MenuChoiceId", res.ProduitId);
                mySqlCmd.Parameters.AddWithValue("@NbPersonne", res.Nombre);


                mySqlCmd.ExecuteNonQuery();

                if (res.Id == 0)
                {
                    // Si c'était un nouveau produit (requête INSERT),
                    // nous affectons le nouvel Id de l'instance au cas où il serait utilisé dans le code appelant.
                    res.Id = (int)mySqlCmd.LastInsertedId;
                }
            }
            finally
            {
                mySqlCnn?.Close();
            }
        }
    }
}
