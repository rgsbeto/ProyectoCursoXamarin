using System;
using System.Collections.Generic;
using System.Text;

namespace EstadisticasFutbol.EntidadNegocio
{
    public class Standing
    {
        public string Stage { get; set; }
        public string Type { get; set; }
        public string Group { get; set; }
        public List<Table> Table { get; set; }
    }
}
