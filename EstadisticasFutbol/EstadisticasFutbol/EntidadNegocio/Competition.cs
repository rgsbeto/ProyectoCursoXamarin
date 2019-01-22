using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace EstadisticasFutbol.EntidadNegocio
{
    public class Competition
    {
        public int Id { get; set; }
        public Area Area { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string EmblemUrl { get; set; }
        public string Plan { get; set; }
        public CurrentSeason CurrentSeason { get; set; }
        public List<Season> Seasons { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
