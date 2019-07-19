using System;
using System.Data.SqlClient;


namespace DbConnection
{
    class Update1
    {
        public void Update1Utente()
        {
            Console.WriteLine("Connessione");
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Test"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                Console.WriteLine("Per modificare un nuovo utente scrivi l'ID utente");
                Console.Write("ID: ");
                string InputId = Console.ReadLine();
                int Id = int.Parse(InputId);

                conn.Open();
                string query = "SELECT Id, Nome, Cognome, DataDiNascita, LuogoDiNascita, ComuneDiResidenza FROM dbo.Studenti WHERE ID = @Id";

                string NomeIniziale = "";
                string CognomeIniziale = "";
                string DateInputIniziale = "3/07/1998";
                string NascitaIniziale = "";
                string ComuneIniziale = "";

                using (SqlCommand connection = new SqlCommand(query, conn))
                {
                    connection.Parameters.AddWithValue("@Id", Id);
                    connection.ExecuteNonQuery();

                    SqlDataReader myReader = connection.ExecuteReader();
                    Console.WriteLine("ID \t Nome \t\t Cognome \t Data di nascita \t Luogo di nascita \t Comune");
                    Console.WriteLine("--------------------------------------------------------------------------------------------------");
                    while (myReader.Read())
                    {
                        NomeIniziale = myReader["Nome"].ToString();
                        CognomeIniziale = myReader["Cognome"].ToString();
                        DateInputIniziale = myReader["DataDiNascita"].ToString();
                        NascitaIniziale = myReader["LuogoDiNascita"].ToString();
                        ComuneIniziale = myReader["ComuneDiResidenza"].ToString();

                        Console.WriteLine("{0}\t{1}\t    {2}\t         {3}\t     {4}\t         {5}",
                        myReader["Id"], myReader["Nome"], myReader["Cognome"], myReader["DataDiNascita"], myReader["LuogoDiNascita"], myReader["ComuneDiResidenza"]);
                        Console.WriteLine();
                    }


                    myReader.Close();
                }
                DateTime DateTimeIniziale = DateTime.Parse(DateInputIniziale);


                Console.WriteLine("Inserisci i dati da modificare");
                Console.Write("Nome: ");
                string Nome = Console.ReadLine();
                Console.Write("Cognome: ");
                string Cognome = Console.ReadLine();
                Console.Write("Data di nascita: ");
                string DateInput = Console.ReadLine();
                DateTime DataDiNascita;
                if (!DateTime.TryParse(DateInput, out DataDiNascita))
                {
                    DataDiNascita = DateTimeIniziale;
                }
                else
                {
                    DataDiNascita = DateTime.Parse(DateInput);
                }
                Console.Write("Luogo di nascita: ");
                string LuogoDiNascita = Console.ReadLine();
                Console.Write("Comune di residenza: ");
                string ComuneDiResidenza = Console.ReadLine();


                string secondQuery = "UPDATE dbo.Studenti SET Nome= @Nome, Cognome=@Cognome, DataDiNascita=@DataDiNascita, LuogoDiNascita=@LuogoDiNascita," +
                    "ComuneDiResidenza=@ComuneDiResidenza WHERE ID=@Id";
                using (SqlCommand connection = new SqlCommand(secondQuery, conn))
                {
                    connection.Parameters.AddWithValue("@Id", Id);

                    if (Nome != "")
                    {
                        connection.Parameters.AddWithValue("@Nome", Nome);
                    }
                    else
                    {
                        connection.Parameters.AddWithValue("@Nome", NomeIniziale);
                    }

                    if (Cognome != "")
                    {
                        connection.Parameters.AddWithValue("@Cognome", Cognome);
                    }
                    else
                    {
                        connection.Parameters.AddWithValue("@Cognome", CognomeIniziale);
                    }

                    connection.Parameters.AddWithValue("@DataDiNascita", DataDiNascita);


                    if (LuogoDiNascita != "")
                    {
                        connection.Parameters.AddWithValue("@LuogoDiNascita", LuogoDiNascita);
                    }
                    else
                    {
                        connection.Parameters.AddWithValue("@LuogoDiNascita", NascitaIniziale);
                    }

                    if (ComuneDiResidenza != "")
                    {
                        connection.Parameters.AddWithValue("@ComuneDiResidenza", ComuneDiResidenza);
                    }
                    else
                    {
                        connection.Parameters.AddWithValue("@ComuneDiResidenza", ComuneIniziale);
                    }
                    connection.ExecuteNonQuery();

                    conn.Close();
                }
            }
        }
    }
}



