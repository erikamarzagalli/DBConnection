using System;
using System.Data.SqlClient;

namespace DbConnection
{
    class Delete
    {
        public void DeleteUtente()
        {
            Console.WriteLine("Connessione");
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Test"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                Console.WriteLine("Per eliminare un nuovo utente inserisci l'ID utente");
                Console.Write("ID: ");
                string InputId = Console.ReadLine();
                int Id = int.Parse(InputId);

                conn.Open();
                string query = "DELETE dbo.Studenti WHERE ID=@Id";
                using (SqlCommand connection = new SqlCommand(query, conn))
                {
                    connection.Parameters.AddWithValue("@Id", Id);
                    connection.ExecuteNonQuery();

                    conn.Close();
                }
            }
        }
    }
}
