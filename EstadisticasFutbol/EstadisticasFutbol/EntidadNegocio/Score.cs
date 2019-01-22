using System;
using System.Collections.Generic;
using System.Text;

namespace EstadisticasFutbol.EntidadNegocio
{
    public class Score
    {
        public string Winner { get; set; }
        public string Duration { get; set; }
        public Marcador FullTime { get; set; }
        public Marcador HalfTime { get; set; }
        public Marcador ExtraTime { get; set; }
        public Marcador Penalties { get; set; }
    }
}
