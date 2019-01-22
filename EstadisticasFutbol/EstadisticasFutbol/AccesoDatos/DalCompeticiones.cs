using EstadisticasFutbol.EntidadNegocio;
using EstadisticasFutbol.Utilerias;
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

            try
            {
                vlo_EjecutorServicioRest = new EjecutorServiciosRest();
                vlo_Encabezados = new List<HttpHeader>();
                vlo_Encabezados.Add(new HttpHeader() { Name = Constantes.HEADER_AUTH_TOKEN, Value = Constantes.AUTH_TOKEN });
                vlo_Resultado = await vlo_EjecutorServicioRest.EjecutarGet<CompetitionList>(Constantes.URL_API_COMPETITIONS, vlo_Encabezados);
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

            try
            {
                vlo_EjecutorServicioRest = new EjecutorServiciosRest();
                vlo_Encabezados = new List<HttpHeader>();
                vlo_Encabezados.Add(new HttpHeader() { Name = Constantes.HEADER_AUTH_TOKEN, Value = Constantes.AUTH_TOKEN });
                vlo_Resultado = await vlo_EjecutorServicioRest.EjecutarGet<TeamList>(string.Format(Constantes.URL_API_COMPETITION_TEAMS,pvn_IdCompeticion), vlo_Encabezados);
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

            try
            {
                vlo_EjecutorServicioRest = new EjecutorServiciosRest();
                vlo_Encabezados = new List<HttpHeader>();
                vlo_Encabezados.Add(new HttpHeader() { Name = Constantes.HEADER_AUTH_TOKEN, Value = Constantes.AUTH_TOKEN });
                vlo_Resultado = await vlo_EjecutorServicioRest.EjecutarGet<StandingList>(string.Format(Constantes.URL_API_COMPETITION_STANDINGS, pvn_IdCompeticion), vlo_Encabezados);
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

            try
            {
                vlo_EjecutorServicioRest = new EjecutorServiciosRest();
                vlo_Encabezados = new List<HttpHeader>();
                vlo_Encabezados.Add(new HttpHeader() { Name = Constantes.HEADER_AUTH_TOKEN, Value = Constantes.AUTH_TOKEN });
                vlo_Resultado = await vlo_EjecutorServicioRest.EjecutarGet<MatchList>(string.Format(Constantes.URL_API_COMPETITION_MATCHES, pvn_IdCompeticion), vlo_Encabezados);
            }
            catch (Exception)
            {
                throw;
            }

            return vlo_Resultado;
        }
    }
}
