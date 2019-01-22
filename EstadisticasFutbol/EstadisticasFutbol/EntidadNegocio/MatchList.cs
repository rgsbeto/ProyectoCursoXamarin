using System;
using System.Collections.Generic;
using System.Text;

namespace EstadisticasFutbol.EntidadNegocio
{
    public class MatchList
    {
        public int Count { get; set; }
        public Filters Filters { get; set; }
        public Competition Competition { get; set; }
        public List<Match> Matches { get; set; }
    }
}
