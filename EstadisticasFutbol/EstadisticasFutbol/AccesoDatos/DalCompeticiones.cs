using EstadisticasFutbol.EntidadNegocio;
using EstadisticasFutbol.Utilerias;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EstadisticasFutbol.AccesoDatos
{
    public class DalCompeticiones
    {
        public async Task<CompetitionList> ListarCompeticiones()
        {
            EjecutorServiciosRest vlo_EjecutorServicioRest;
            List<HttpHeader> vlo_Encabezados;
            CompetitionList vlo_Resultado = new CompetitionList();
            DataCache vlo_Cache = null;

            try
            {
                vlo_Cache = await App.BaseDatos.ObtenerCache(Constantes.URL_API_COMPETITIONS);
                if (vlo_Cache == null)
                {
                    vlo_EjecutorServicioRest = new EjecutorServiciosRest();
                    vlo_Encabezados = new List<HttpHeader>();
                    vlo_Encabezados.Add(new HttpHeader() { Name = Constantes.HEADER_AUTH_TOKEN, Value = Constantes.AUTH_TOKEN });
                    vlo_Resultado = await vlo_EjecutorServicioRest.EjecutarGet<CompetitionList>(Constantes.URL_API_COMPETITIONS, vlo_Encabezados);
                    vlo_Cache = new DataCache() { Url = Constantes.URL_API_COMPETITIONS, Expires = DateTime.Now.AddMinutes(Constantes.MINUTOS_VIGENCIA_CACHE), Data = JsonConvert.SerializeObject(vlo_Resultado) };
                    await App.BaseDatos.Salvar(vlo_Cache);
                }
                else
                {
                    vlo_Resultado = JsonConvert.DeserializeObject<CompetitionList>(vlo_Cache.Data, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, MissingMemberHandling = MissingMemberHandling.Ignore });
                }
            }
            catch (Exception)
            {
                throw;
            }

            return vlo_Resultado;
        }

        public async Task<TeamList> ListarEquipos(int pvn_IdCompeticion)
        {
            EjecutorServiciosRest vlo_EjecutorServicioRest;
            List<HttpHeader> vlo_Encabezados;
            TeamList vlo_Resultado = new TeamList();
            DataCache vlo_Cache = null;
            string vlc_Url;

            try
            {
                vlc_Url = string.Format(Constantes.URL_API_COMPETITION_TEAMS, pvn_IdCompeticion);
                vlo_Cache = await App.BaseDatos.ObtenerCache(vlc_Url);
                if (vlo_Cache == null)
                {
                    vlo_EjecutorServicioRest = new EjecutorServiciosRest();
                    vlo_Encabezados = new List<HttpHeader>();
                    vlo_Encabezados.Add(new HttpHeader() { Name = Constantes.HEADER_AUTH_TOKEN, Value = Constantes.AUTH_TOKEN });
                    vlo_Resultado = await vlo_EjecutorServicioRest.EjecutarGet<TeamList>(vlc_Url, vlo_Encabezados);

                    vlo_Cache = new DataCache() { Url = vlc_Url, Expires = DateTime.Now.AddMinutes(Constantes.MINUTOS_VIGENCIA_CACHE), Data = JsonConvert.SerializeObject(vlo_Resultado) };
                    await App.BaseDatos.Salvar(vlo_Cache);
                }
                else
                {
                    vlo_Resultado = JsonConvert.DeserializeObject<TeamList>(vlo_Cache.Data, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, MissingMemberHandling = MissingMemberHandling.Ignore });
                }
            }
            catch (Exception)
            {
                throw;
            }

            return vlo_Resultado;
        }

        public async Task<StandingList> ListarEstadisticas(int pvn_IdCompeticion)
        {
            EjecutorServiciosRest vlo_EjecutorServicioRest;
            List<HttpHeader> vlo_Encabezados;
            StandingList vlo_Resultado = new StandingList();
            DataCache vlo_Cache = null;
            string vlc_Url;

            try
            {
                vlc_Url = string.Format(Constantes.URL_API_COMPETITION_STANDINGS, pvn_IdCompeticion);
                vlo_Cache = await App.BaseDatos.ObtenerCache(vlc_Url);
                if (vlo_Cache == null)
                {
                    vlo_EjecutorServicioRest = new EjecutorServiciosRest();
                    vlo_Encabezados = new List<HttpHeader>();
                    vlo_Encabezados.Add(new HttpHeader() { Name = Constantes.HEADER_AUTH_TOKEN, Value = Constantes.AUTH_TOKEN });
                    vlo_Resultado = await vlo_EjecutorServicioRest.EjecutarGet<StandingList>(vlc_Url, vlo_Encabezados);

                    vlo_Cache = new DataCache() { Url = vlc_Url, Expires = DateTime.Now.AddMinutes(Constantes.MINUTOS_VIGENCIA_CACHE), Data = JsonConvert.SerializeObject(vlo_Resultado) };
                    await App.BaseDatos.Salvar(vlo_Cache);
                }
                else
                {
                    vlo_Resultado = JsonConvert.DeserializeObject<StandingList>(vlo_Cache.Data, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, MissingMemberHandling = MissingMemberHandling.Ignore });
                }
            }
            catch (Exception)
            {
                throw;
            }

            return vlo_Resultado;
        }

        public async Task<MatchList> ListarPartidos(int pvn_IdCompeticion)
        {
            EjecutorServiciosRest vlo_EjecutorServicioRest;
            List<HttpHeader> vlo_Encabezados;
            MatchList vlo_Resultado = new MatchList();
            DataCache vlo_Cache = null;
            string vlc_Url;

            try
            {
                vlc_Url = string.Format(Constantes.URL_API_COMPETITION_MATCHES, pvn_IdCompeticion);
                vlo_Cache = await App.BaseDatos.ObtenerCache(vlc_Url);
                if (vlo_Cache == null)
                {
                    vlo_EjecutorServicioRest = new EjecutorServiciosRest();
                    vlo_Encabezados = new List<HttpHeader>();
                    vlo_Encabezados.Add(new HttpHeader() { Name = Constantes.HEADER_AUTH_TOKEN, Value = Constantes.AUTH_TOKEN });
                    vlo_Resultado = await vlo_EjecutorServicioRest.EjecutarGet<MatchList>(vlc_Url, vlo_Encabezados);

                    vlo_Cache = new DataCache() { Url = vlc_Url, Expires = DateTime.Now.AddMinutes(Constantes.MINUTOS_VIGENCIA_CACHE), Data = JsonConvert.SerializeObject(vlo_Resultado) };
                    await App.BaseDatos.Salvar(vlo_Cache);
                }
                else
                {
                    vlo_Resultado = JsonConvert.DeserializeObject<MatchList>(vlo_Cache.Data, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, MissingMemberHandling = MissingMemberHandling.Ignore });
                }
            }
            catch (Exception)
            {
                throw;
            }

            return vlo_Resultado;
        }
    }
}
