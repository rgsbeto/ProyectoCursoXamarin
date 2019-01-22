using EstadisticasFutbol.AccesoDatos;
using EstadisticasFutbol.EntidadNegocio;
using EstadisticasFutbol.Utilerias;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EstadisticasFutbol.LogicaNegocio
{
    public class BllCompeticiones
    {
        public async Task<List<Competition>> ListarCompeticiones()
        {
            DalCompeticiones vlo_DalCompeticiones;
            CompetitionList vlo_ListaDeCompeticiones;
            List<Competition> vlo_Resultado = new List<Competition>();          

            try
            {
                vlo_DalCompeticiones = new DalCompeticiones();
                vlo_ListaDeCompeticiones = await vlo_DalCompeticiones.ListarCompeticiones();

                if (vlo_ListaDeCompeticiones != null && vlo_ListaDeCompeticiones.Count > 0)
                {
                    foreach (var vlo_Competicion in vlo_ListaDeCompeticiones.Competitions)
                    {
                        if (Constantes.COMPETICIONES_AUTORIZADAS.Contains(vlo_Competicion.Id.ToString()))
                        {
                            vlo_Resultado.Add(vlo_Competicion);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return vlo_Resultado;
        }

        public async Task<List<Team>> ListarEquipos(int pvn_IdCompeticion)
        {
            DalCompeticiones vlo_DalCompeticiones;
            TeamList vlo_ListaDeEquipos;
            List<Team> vlo_Resultado = new List<Team>();

            try
            {
                vlo_DalCompeticiones = new DalCompeticiones();
                vlo_ListaDeEquipos = await vlo_DalCompeticiones.ListarEquipos(pvn_IdCompeticion);

                if (vlo_ListaDeEquipos != null && vlo_ListaDeEquipos.Count > 0)
                {
                    foreach (var vlo_Equipo in vlo_ListaDeEquipos.Teams)
                    {
                        vlo_Resultado.Add(vlo_Equipo);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return vlo_Resultado;
        }

        public async Task<List<Table>> ListarEstadisticas(int pvn_IdCompeticion)
        {
            DalCompeticiones vlo_DalCompeticiones;
            StandingList vlo_ListaDeEstadisticas;
            List<Table> vlo_Resultado = null;

            try
            {
                vlo_DalCompeticiones = new DalCompeticiones();
                vlo_ListaDeEstadisticas = await vlo_DalCompeticiones.ListarEstadisticas(pvn_IdCompeticion);

                if (vlo_ListaDeEstadisticas != null && vlo_ListaDeEstadisticas.Standings != null && vlo_ListaDeEstadisticas.Standings.Count > 0)
                {
                    vlo_Resultado = vlo_ListaDeEstadisticas.Standings[0].Table;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return vlo_Resultado;
        }

        public async Task<List<Match>> ListarPartidos(int pvn_IdCompeticion, int pvn_IdEquipo)
        {
            DalCompeticiones vlo_DalCompeticiones;
            MatchList vlo_ListaDePartidos;
            List<Match> vlo_Resultado = new List<Match>();

            try
            {
                vlo_DalCompeticiones = new DalCompeticiones();
                vlo_ListaDePartidos = await vlo_DalCompeticiones.ListarPartidos(pvn_IdCompeticion);

                if (vlo_ListaDePartidos != null && vlo_ListaDePartidos.Matches != null && vlo_ListaDePartidos.Matches.Count > 0)
                {
                    foreach (var Partido in vlo_ListaDePartidos.Matches)
                    {
                        if (Partido.HomeTeam != null && Partido.AwayTeam != null)
                        {
                            if (Partido.HomeTeam.Id == pvn_IdEquipo || Partido.AwayTeam.Id == pvn_IdEquipo)
                            {
                                vlo_Resultado.Add(Partido);
                            }
                        }
                    }
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
