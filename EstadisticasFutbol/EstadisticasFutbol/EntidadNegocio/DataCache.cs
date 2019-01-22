using System;
using SQLite;

namespace EstadisticasFutbol.EntidadNegocio
{
    public class DataCache
    {
        [PrimaryKey]
        public string Url { get; set; }
        public DateTime Expires { get; set; }
        public string Data { get; set; }
    }
}
