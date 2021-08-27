using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner
{
    public class ImpegnoListRepository : IImpegnoRepository
    {
        public static List<Impegno> impegni = new List<Impegno>
        {
             new Impegno("Visita Medica", "Descrizione Visita", new DateTime(2020, 02, 20) , Impegno._Importanza.Alta, true, null),
             new Impegno("Riunione Lavoro", "Descrizione Riunione", new DateTime(2021, 03, 15) , Impegno._Importanza.Media, false, null),
             new Impegno("Acquisto Scrivania", "Descrizione Acquisto", new DateTime(2021, 04, 20), Impegno._Importanza.Bassa, true, null)
             };
        public void Delete(Impegno impegno)
        {
            impegni.Remove(impegno);
        }

        public List<Impegno> Fetch()
        {
            return impegni;
        }

        public void Insert(Impegno impegno)
        {
            impegni.Add(impegno);
        }

        public void Update(Impegno impegno)
        {
            Insert(impegno);
        }
    }
}
