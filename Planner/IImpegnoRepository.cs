using System.Collections.Generic;

namespace Planner
{
    internal interface IImpegnoRepository
    {
        public List<Impegno> Fetch();

    }
}