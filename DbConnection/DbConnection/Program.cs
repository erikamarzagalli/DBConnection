using System;
using System.Configuration;

namespace DbConnection
{
    class Program
    {
        public static void Main()
        {
            Program p = new Program();
            p.ChooseAction();
        }

        public void ChooseAction()
        {
            bool LoopBreak = true;
            while (LoopBreak == true)
            {
                Insert i = new Insert();
                RunData r = new RunData();
                Update1 u = new Update1();
                Delete d = new Delete();
                Console.WriteLine("Cosa vuoi fare?");
                Console.WriteLine("1 - Visualizzare dati");
                Console.WriteLine("2 - Inserire Utente");
                Console.WriteLine("3 - Modificare Utente");
                Console.WriteLine("4 - Eliminare Utente");
                Console.WriteLine("5 - EXIT");

                int scelta;
                while (Int32.TryParse(Console.ReadLine(), out scelta) && (scelta != 1 && scelta != 2 && scelta != 3 && scelta != 4 && scelta != 5))
                {
                    Console.WriteLine("Valore inserito non valido, riprova");
                }
                Console.Clear();


                switch (scelta)
                {
                    case 1:
                        r.RunStudenti();
                        Console.WriteLine();
                        break;
                    case 2:
                        i.InsertUtente();
                        Console.WriteLine();
                        break;
                    case 3:
                        r.RunStudenti();
                        Console.WriteLine();
                        u.Update1Utente();
                        Console.WriteLine();
                        break;
                    case 4:
                        r.RunStudenti();
                        Console.WriteLine();
                        d.DeleteUtente();
                        Console.WriteLine();
                        break;
                    case 5:
                        LoopBreak = false;
                        break;
                }
            }
        }

    }
}


