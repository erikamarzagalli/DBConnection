using System;
using System.Data.SqlClient;
using System.Configuration;

namespace DbConnection
{
    class RunData
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Test"].ConnectionString;

        // CONNESSIONE TAB AULE
        public void RunAule()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Aule", conn);
                try
                {
                    conn.Open();
                    SqlDataReader myReader = cmd.ExecuteReader();
                    Console.WriteLine("ID \t Descrizione \t Indirizzo");
                    Console.WriteLine("--------------------------------------------------------------------------------------------------");
                    while (myReader.Read())
                    {
                        Console.WriteLine("{0}\t{1}\t\t{2}", myReader["ID"], myReader["Descrizione"], myReader["IndirizzoCompleto"]);
                    }
                    myReader.Close();
                    conn.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception Occured -->> {0}", e);
                }
                Console.WriteLine();

            }
        }


        // CONNESSIONE TAB CORSI
        public void RunCorsi()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd1 = new SqlCommand("SELECT * FROM dbo.Corsi", conn);
                try
                {
                    conn.Open();
                    SqlDataReader myReader = cmd1.ExecuteReader();
                    Console.WriteLine("ID \t Titolo \t Difficoltà \t Data Inizio \t\t Data fine \t\t Aula");
                    Console.WriteLine("--------------------------------------------------------------------------------------------------");
                    while (myReader.Read())
                    {
                        Console.WriteLine("{0}\t{1}\t\t{2}\t{3}\t{4}\t\t{5}",
                        myReader["ID"], myReader["Titolo"], myReader["Difficolta"], myReader["DataDiInizio"], myReader["DataDiFine"], myReader["Aula"]);
                    }
                    myReader.Close();
                    conn.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception Occured -->> {0}", e);
                }
                Console.WriteLine();
            }
        }


        // CONNESSIONE TAB PARTECIPAZIONI
        public void RunPartecipazioni()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd2 = new SqlCommand("SELECT * FROM dbo.Partecipazioni", conn);
                try
                {
                    conn.Open();
                    SqlDataReader myReader = cmd2.ExecuteReader();
                    Console.WriteLine("ID studente \t ID corso \t Votazione");
                    Console.WriteLine("--------------------------------------------------------------------------------------------------");
                    while (myReader.Read())
                    {
                        Console.WriteLine("{0}\t\t{1}\t\t{2}",
                        myReader["IDStudente"], myReader["IDCorso"], myReader["Votazione"]);
                    }
                    myReader.Close();
                    conn.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception Occured -->> {0}", e);
                }
                Console.WriteLine();
            }
        }


        // CONNESSIONE TAB STUDENTI
        public void RunStudenti()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd3 = new SqlCommand("SELECT * FROM dbo.Studenti", conn);
                try
                {
                    conn.Open();

                    SqlDataReader myReader = cmd3.ExecuteReader();
                    Console.WriteLine("ID \t Nome \t\t Cognome \t Data di nascita \t Luogo di nascita \t Comune");
                    Console.WriteLine("--------------------------------------------------------------------------------------------------");
                    while (myReader.Read())
                    {
                        Console.WriteLine("{0}\t{1}\t   {2}\t         {3}\t     {4}\t         {5}",
                        myReader["Id"], myReader["Nome"], myReader["Cognome"], myReader["DataDiNascita"], myReader["LuogoDiNascita"], myReader["ComuneDiResidenza"]);
                    }
                    myReader.Close();
                    conn.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception Occured -->> {0}", e);
                }
            }
        }


    }
}
