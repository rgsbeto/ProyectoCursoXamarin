﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EstadisticasFutbol.EntidadNegocio
{
    public class Team
    {
        public int Id { get; set; }
        public Area Area { get; set; }
        public List<ActiveCompetition> ActiveCompetitions { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Tla { get; set; }
        public string CrestUrl { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public int Founded { get; set; }
        public string ClubColors { get; set; }
        public string Venue { get; set; }
        public List<Squad> Squad { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
