using System;
using System.Collections.Generic;
using System.Text;

namespace EstadisticasFutbol.EntidadNegocio
{ 
    public class CompetitionList
    {
        public int Count { get; set; }
        public Filters Filters { get; set; }
        public List<Competition> Competitions { get; set; }

        public CompetitionList()
        {
            Count = 0;
            Filters = null;
            Competitions = null;
        }
    }
}
