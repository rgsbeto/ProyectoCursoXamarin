using EstadisticasFutbol.AccesoDatos;
using EstadisticasFutbol.EntidadNegocio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EstadisticasFutbol.LogicaNegocio
{
    public class BllEquipos
    {
        public async Task<List<Squad>> ListarPlantilla(int pvn_IdEquipo)
        {
            DalEquipos vlo_DalEquipos;
            Team vlo_Equipo;
            List<Squad> vlo_Resultado = null;

            try
            {
                vlo_DalEquipos = new DalEquipos();
                vlo_Equipo = await vlo_DalEquipos.ObtenerEquipo(pvn_IdEquipo);

                if (vlo_Equipo != null && vlo_Equipo.Squad != null && vlo_Equipo.Squad.Count > 0)
                {
                    vlo_Resultado = vlo_Equipo.Squad;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return vlo_Resultado;
        }

        public async Task<List<ActiveCompetition>> ListarCompeticionesActivas(int pvn_IdEquipo)
        {
            DalEquipos vlo_DalEquipos;
            Team vlo_Equipo;
            List<ActiveCompetition> vlo_Resultado = null;

            try
            {
                vlo_DalEquipos = new DalEquipos();
                vlo_Equipo = await vlo_DalEquipos.ObtenerEquipo(pvn_IdEquipo);

                if (vlo_Equipo != null && vlo_Equipo.ActiveCompetitions != null && vlo_Equipo.ActiveCompetitions.Count > 0)
                {
                    vlo_Resultado = vlo_Equipo.ActiveCompetitions;
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
