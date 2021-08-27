using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Planner.Impegno;

namespace Planner
{


    class DealManager
    {
        public static ImpegnoRepository impegnoRepository = new ImpegnoRepository();


        internal static void ShowImpegno()
        {
            List<Impegno> impegno = impegnoRepository.Fetch();
            foreach (var impegni in impegno)
            {
                Console.WriteLine(impegni.Print());
            }
        }

        internal static void UpdateImpegno()
        {
            List<Impegno> impegno = impegnoRepository.Fetch();
            int i = 1;
            foreach (var im in impegno)
            {
                Console.WriteLine($"Premi {i} per modificare l'impegno {im.Print()}");
                i++;
            }
            int impegnoScelto;
            bool isInt;

            do
            {
                Console.WriteLine("Quale impegno?");

                isInt = int.TryParse(Console.ReadLine(), out impegnoScelto);

            } while (!isInt || impegnoScelto <= 0 || impegnoScelto > impegno.Count);

            Console.WriteLine("Hai scelto di modificare");
            Impegno impegni = impegno.ElementAt(impegnoScelto - 1);

            if (impegno == null)
            {
                impegnoRepository.Delete(impegno);
            }
            else
            {
            }

            bool contin = true;
            string reply;
            do
            {
                Console.WriteLine("Vuoi modificare il Titolo?");
                reply = Console.ReadLine();
                if (reply == "si" || reply == "no")
                    contin = false;
            } while (contin);
            if (reply == "si")
            {
                impegni.Titolo = InsertTitle();
            }

            do
            {
                Console.WriteLine("Vuoi modificare la Descrizione?");
                reply = Console.ReadLine();
                if (reply == "si" || reply == "no")
                    contin = false;
            } while (contin);
            if (reply == "si")
            {
                impegni.Descrizione = InsertDesc();
            }
            do
            {
                Console.WriteLine("Vuoi modificare la data dell'impegno?");
                reply = Console.ReadLine();
                if (reply == "si" || reply == "no")
                    contin = false;
            } while (contin);
            if (reply == "si")
            {
                impegni.DataScadenza = InsertDate();
            }

            do
            {
                Console.WriteLine("Vuoi modificare la priorità?");
                reply = Console.ReadLine();
                if (reply == "si" || reply == "no")
                    contin = false;
            } while (contin);
            if (reply == "si")
            {
                impegni.Importanza = InsertPriority();
            }

            do
            {
                Console.WriteLine("Vuoi modificare se è stato completato o no?");
                reply = Console.ReadLine();
                if (reply == "si" || reply == "no")
                    contin = false;
            } while (contin);
            if (reply == "si")
            {
                impegni.Terminato = InsertComplete();
            }
            impegnoRepository.Update(impegno);

        }

        internal static void GetByPriority()
        {
            _Importanza imp = InsertImpegno();
            List<Impegno> impegni = impegnoRepository.GetByImportanza();
            foreach (var im in impegni)
                Console.WriteLine(imp.Print());
        }

        private static _Importanza InsertImpegno()
        {
            throw new NotImplementedException();
        }

        internal static void GetByComplete()
        {
            string impegniterminati;

            List<Impegno> impegni = impegnoRepository.Fetch();
            foreach (var impt in impegni)
            {

                Console.WriteLine(impt.Print());
            }

            if (Impegno.Terminato == false) impegniterminati = Impegno.Terminato;

            Console.WriteLine($"Gli impegni terminati sono {impegniterminati}");

        }


        private static DateTime ChiediData()
        {
            {
                DateTime dt;
                do
                {
                    Console.WriteLine("Inserisci una data");
                } while (!DateTime.TryParse(Console.ReadLine(), out dt));

                return dt;
            }
        }

        internal static void GetByDate()
        {
            DateTime dt = ChiediData();
            List<Impegno> impegni = impegnoRepository.GetByDate(dt);
            Print(impegni);
        }

        private static void Print(List<Impegno> impegni)
        {
            foreach (var impegno in impegni)
            {
                impegno.Print();
            }
        }

            internal static void InsertImpegno()
            {
                Impegno impegno = new Impegno();

                impegno.Titolo = InsertTitle();
                impegno.Descrizione = InsertDesc();
                impegno.DataScadenza = InsertDate();
                impegno.Importanza = InsertPriority();
                impegno.Terminato = InsertComplete();

                impegnoRepository.Insert(impegno);
            }

            internal static void DeleteImpegno()
            {
                List<Impegno> impegni = impegnoRepository.Fetch();

                int i = 1;
                foreach (var impegno in impegni)
                {
                    Console.WriteLine($"Digita {i} per eliminare l'Impegno {impegno.Print()}");
                    i++;
                }

                bool isInt;
                int impegnoScelto;
                do
                {
                    Console.WriteLine("Quale impegno?");

                    isInt = int.TryParse(Console.ReadLine(), out impegnoScelto);

                } while (!isInt || impegnoScelto <= 0 || impegnoScelto > impegni.Count);

                impegnoRepository.Delete(impegni.ElementAt(impegnoScelto - 1));
            }

            private static bool InsertComplete()
            {
                bool contin = true;
                string reply;
                do
                {
                    Console.WriteLine("L'impegno è completato? Premi Y per 'sì' o N per 'no'");
                    reply = Console.ReadLine();
                    if (reply == "Y" || reply == "N")
                        contin = false;
                } while (contin);

                return reply == "Y" ? true : false;
            }

            private static _Importanza InsertPriority()
            {
                bool isInt = false;
                int importanza = 0;
                do
                {
                    Console.WriteLine("Inserisci la priorità");
                    foreach (var priority in Enum.GetValues(typeof(_Importanza)))
                    {
                        Console.WriteLine($"Premi {(int)importanza} per {(_Importanza)priority}");
                    }

                    isInt = int.TryParse(Console.ReadLine(), out importanza);
                } while (!isInt || importanza < 1 || importanza > 2);
                return (Impegno._Importanza)importanza;
            }

            private static DateTime InsertDate()
            {
                DateTime dt = new DateTime();
                bool isDate;
                do
                {
                    Console.WriteLine("Inserisci la data di scadenza");

                    isDate = DateTime.TryParse(Console.ReadLine(), out dt);

                } while (!isDate);
                return dt;
            }

            private static string InsertDesc()
            {
                string descrizione = String.Empty;
                do
                {
                    Console.WriteLine("Inserisci Descrizione");
                    descrizione = Console.ReadLine();

                } while (String.IsNullOrEmpty(descrizione));
                return descrizione;
            }


            private static string InsertTitle()
            {
                string titolo = String.Empty;
                do
                {
                    Console.WriteLine("Inserisci Titolo");
                    titolo = Console.ReadLine();

                } while (String.IsNullOrEmpty(titolo));
                return titolo;
            }
        }


    } 