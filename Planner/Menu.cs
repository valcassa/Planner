using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner
{

    //Il programma permette di:

    //Opzionali:
    //- nella modifica di un impegno rendere lo stato di “portato a termine” non modificabile
      
    //- aggiungere una funzione che, scelto un impegno metta il flag portato a termine(NB.è possibile portare a
    //termine impegni non ancora portati a termine) 

    class Menu
    {
        internal static void Start()
    {

        bool continuare = true;
        do
        {
            Console.WriteLine("**** AGENDA ****");
                 
            Console.WriteLine("1 - Visualizza tutti gli impegni");
            Console.WriteLine("2 - Modifica un impegno");
            Console.WriteLine("3 - Elimina un impegno");
            Console.WriteLine("4 - Inserisci un nuovo impegno");
            Console.WriteLine("5 - Ordina per data");
            Console.WriteLine("6 - Ordina per priorità");
            Console.WriteLine("7 - Visualizza impegni terminati");

            Console.WriteLine("0 - Esci dal programma");
                 
                Console.WriteLine();


            string scelta = Console.ReadLine();

            switch (scelta)
            {
                case "1":
                    DealManager.ShowImpegno();
                    break;
                case "2":
                    DealManager.UpdateImpegno();
                    break;
                case "3":
                    DealManager.DeleteImpegno();
                    break;
                case "4":
                    DealManager.InsertImpegno();
                    break;
                case "5":
                    DealManager.GetByDate();
                    break;
                case "6":
                    DealManager.GetByPriority();
                    break;

                case "7":
                    DealManager.GetByComplete();
                    break; 

                case "0":
                    Console.WriteLine("L'applicazione si chiude");
                    continuare = false;
                    break;
                default:
                    Console.WriteLine("Scelta sbagliata riprova");
                    break;
            }
        } while (continuare);
    }
}
}
