using System;
using System.Data.SqlClient;
using System.Configuration;

namespace DbConnection
{
    class Update
    {
        public void UpdateUtente()
        {
            Console.WriteLine("Connessione");
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Test"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                Console.WriteLine("Per modificare un nuovo utente scrivi l'ID utente");
                Console.Write("ID: ");
                string InputId = Console.ReadLine();
                int Id = int.Parse(InputId);

                Console.Write("Nome: ");
                string Nome = Console.ReadLine();
                Console.Write("Cognome: ");
                string Cognome = Console.ReadLine();
                Console.Write("Data di nascita: ");
                string DateInput = Console.ReadLine();
                DateTime DataDiNascita = DateTime.Parse(DateInput);
                Console.Write("Luogo di nascita: ");
                string LuogoDiNascita = Console.ReadLine();
                Console.Write("Comune di residenza: ");
                string ComuneDiResidenza = Console.ReadLine();


                conn.Open();
                string query = "UPDATE dbo.Studenti SET Nome= @Nome, Cognome=@Cognome, DataDiNascita=@DataDiNascita, LuogoDiNascita=@LuogoDiNascita," +
                    "ComuneDiResidenza=@ComuneDiResidenza WHERE ID=@Id";
                using (SqlCommand connection = new SqlCommand(query, conn))
                {
                    connection.Parameters.AddWithValue("@Id", Id);
                    if (Nome != "")
                    {
                        connection.Parameters.AddWithValue("@Nome", Nome);
                    }
                    if (Cognome != "")
                    {
                        connection.Parameters.AddWithValue("@Cognome", Cognome);
                    }
                    if (DateInput != "")
                    {
                        connection.Parameters.AddWithValue("@DataDiNascita", DataDiNascita);
                    }
                    if (LuogoDiNascita != "")
                    {
                        connection.Parameters.AddWithValue("@LuogoDiNascita", LuogoDiNascita);
                    }
                    if (ComuneDiResidenza != "")
                    {
                        connection.Parameters.AddWithValue("@ComuneDiResidenza", ComuneDiResidenza);
                    }
                    connection.ExecuteNonQuery();



                    conn.Close();
                }
            }
        }
    }
}

