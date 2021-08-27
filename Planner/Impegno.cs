using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner { 
    public class Impegno
    {
        public string Titolo { get; set; }
        public string Descrizione { get; set; }
        public DateTime DataScadenza { get; set; }
        public _Importanza Importanza { get; set; }
        public bool Terminato { get; set; }

        public int? Id { get; set; }


        public Impegno(string title, string desc, DateTime deadline, _Importanza priority, bool complete, int?id)
        {
            Titolo = title;
            Descrizione = desc;
            DataScadenza = deadline;
            Importanza = priority;
            Terminato = complete;
            Terminato = false;
            Id = id;


        }

        public enum _Importanza
        {
            Alta,
            Media,
            Bassa
        }
        public Impegno()
        {
        }

        public virtual string Print()
        {
            return $"{Titolo}, {Descrizione},{Terminato}";
        }
    }
}
