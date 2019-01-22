using System;
using System.Collections.Generic;
using System.Text;

namespace EstadisticasFutbol.EntidadNegocio
{
    public class Match
    {
        public int Id { get; set; }
        public Season Season { get; set; }
        public DateTime UtcDate { get; set; }
        public string Status { get; set; }
        public int Matchday { get; set; }
        public string Stage { get; set; }
        public string Group { get; set; }
        public DateTime LastUpdated { get; set; }
        public Score Score { get; set; }
        public TeamInfo HomeTeam { get; set; }
        public TeamInfo AwayTeam { get; set; }
        public List<Referee> Referees { get; set; }
    }
}
