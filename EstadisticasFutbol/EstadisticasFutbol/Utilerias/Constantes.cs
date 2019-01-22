using System;
using System.Collections.Generic;
using System.Text;

namespace EstadisticasFutbol.Utilerias
{
    public class Constantes
    {
        public const string URL_API_BASE = "https://api.football-data.org/v2/";
        public const string URL_API_COMPETITIONS = URL_API_BASE + "competitions";
        public const string URL_API_COMPETITION_TEAMS = URL_API_BASE + "competitions/{0}/teams";
        public const string URL_API_COMPETITION_STANDINGS = URL_API_BASE + "competitions/{0}/standings?standingType=TOTAL";
        public const string URL_API_COMPETITION_MATCHES = URL_API_BASE + "competitions/{0}/matches";
        public const string URL_API_TEAMS = URL_API_BASE + "teams/{0}";
        public const string HEADER_AUTH_TOKEN = "X-Auth-Token";
        public const string AUTH_TOKEN = "ac105f57b00045269042a16f8b9ec03f";
        public const string COMPETICIONES_AUTORIZADAS = "2002;2003;2013;2014;2015;2016;2017;2019;2021";
        public const string MIME_TYPE_JSON = "application/json";
        public const int MINUTOS_VIGENCIA_CACHE = 5;
    }
}
