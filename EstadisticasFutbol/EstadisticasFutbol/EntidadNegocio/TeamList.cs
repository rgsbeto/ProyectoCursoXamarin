using System;
using System.Collections.Generic;
using System.Text;

namespace EstadisticasFutbol.EntidadNegocio
{
    public class TeamList
    {
        public int Count { get; set; }
        public Filters Filters { get; set; }
        public Competition Competition { get; set; }
        public Season Season { get; set; }
        public List<Team> Teams { get; set; }
    }
}
