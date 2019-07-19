using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DbConnection
{
    class Insert
    {
        public void InsertUtente()
        {
            Console.WriteLine("Connessione");
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Test"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                Console.WriteLine("Per inserire un nuovo utente scrivi i seguenti dati");
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
                string query = "INSERT INTO dbo.Studenti(Nome, Cognome, DataDiNascita, LuogoDiNascita, ComuneDiResidenza)VALUES(@Nome, @Cognome, @DataDiNascita, @LuogoDiNascita, @ComuneDiResidenza )";
                using (SqlCommand connection = new SqlCommand(query, conn))
                {
                    connection.Parameters.Add("@Nome", SqlDbType.VarChar).Value = Nome;
                    connection.Parameters.Add("@Cognome", SqlDbType.VarChar).Value = Cognome;
                    connection.Parameters.Add("@DataDiNascita", SqlDbType.DateTime).Value = DataDiNascita;
                    connection.Parameters.Add("@LuogoDiNascita", SqlDbType.VarChar).Value = LuogoDiNascita;
                    connection.Parameters.Add("@ComuneDiResidenza", SqlDbType.VarChar).Value = ComuneDiResidenza;
                    connection.CommandType = CommandType.Text;
                    connection.ExecuteNonQuery();

                    conn.Close();
                }
            }
        }

    }
}
