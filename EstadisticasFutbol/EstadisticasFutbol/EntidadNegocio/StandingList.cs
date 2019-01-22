using System;
using System.Collections.Generic;
using System.Text;

namespace EstadisticasFutbol.EntidadNegocio
{
    public class StandingList
    {
        public Filters Filters { get; set; }
        public Competition Competition { get; set; }
        public Season Season { get; set; }
        public List<Standing> Standings { get; set; }
    }
}
