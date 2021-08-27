using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Planner.Impegno;

namespace Planner
{
    public class ImpegnoRepository : IImpegnoRepository
    {
        const string connectionString = @"Data Source = (localdb)\mssqllocaldb;" +
                                       "Initial Catalog = Planner;" +
                                       "Integrated Security = true;";

        const string discriminator = "Impegno";

        public static ImpegnoRepository impegnoRepository = new ImpegnoRepository();
        List<Impegno> impegni = new List<Impegno>();

        public List<Impegno> Fetch()
        {
            List<Impegno> impegni = new List<Impegno>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Planner";

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var title = (string)reader["Titolo"];
                    var desc = (string)reader["Descrizione"];
                    var deadline = (DateTime)reader["Data Scadenza"];
                    var priority = (_Importanza)reader["Importanza"];
                    var complete = (bool)reader["Terminato"];
                    var id = (int)reader["Id"];

                    Impegno impegno = new Impegno(title, desc, deadline, priority, complete, id);

                    impegni.Add(impegno);
                }
            }
            return impegni;
        }


        public void Update(Impegno impegno)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "update Impegno" + "set Titolo = @title, Descrizione = @desc, DataScadenza = @deadline,"+
                                       "Importanza = @priority, Terminato = @complete, discriminator = @discriminator"+
                                       "where Id = @id";


                command.Parameters.AddWithValue("@title", impegno.Titolo);
                command.Parameters.AddWithValue("@desc", impegno.Descrizione);
                command.Parameters.AddWithValue("@deadline", impegno.DataScadenza);
                command.Parameters.AddWithValue("@priority", impegno.Importanza);
                command.Parameters.AddWithValue("@complete", impegno.Terminato);
                command.Parameters.AddWithValue("@id", impegno.Id);


                command.ExecuteNonQuery();

                 }
            }
       }

    public void Insert(Impegno impegno)
    {

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "insert into Impegno values(@title, @desc, @deadline, @priority, @complete, @discriminator)";


            command.Parameters.AddWithValue("@title", impegno.Titolo);
            command.Parameters.AddWithValue("@desc", impegno.Descrizione);
            command.Parameters.AddWithValue("@deadline", impegno.DataScadenza);
            command.Parameters.AddWithValue("@priority", impegno.Importanza);
            command.Parameters.AddWithValue("@complete", impegno.Terminato);
            command.Parameters.AddWithValue("@id", impegno.Id);


            command.ExecuteNonQuery();
        }
    }
        public void Delete(Impegno impegno)
        {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "delete from Impegno where Id = @id";
                command.Parameters.AddWithValue("@id", impegno.Id);

                command.ExecuteNonQuery();
            }
        }

        internal List<Impegno> GetByImportanza(Impegno._Importanza imp)
        {
            List<Impegno> impegni = new List<Impegno>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Impegno where Importanza = @priority";
                command.Parameters.AddWithValue("@priority", (int)imp);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var title = (string)reader["Titolo"];
                    var desc = (string)reader["Descrizione"];
                    var deadline = (DateTime)reader["Data Scadenza"];
                    var priority = (_Importanza)reader["Importanza"];
                    var complete = (bool)reader["Terminato"];
                    var id = (int)reader["Id"];

                    Impegno impegno = new Impegno(title, desc, deadline, priority, complete, id);

                    impegni.Add(impegno);
                }
            }
            return impegni;
        }

        internal List<Impegno> GetByImportanza()
        {
            throw new NotImplementedException();
        }

        internal List<Impegno> GetByComplete()
        {
            throw new NotImplementedException();
        }

        internal List<Impegno> GetByDate(DateTime dt)
        {
            throw new NotImplementedException();
        }
    }
}