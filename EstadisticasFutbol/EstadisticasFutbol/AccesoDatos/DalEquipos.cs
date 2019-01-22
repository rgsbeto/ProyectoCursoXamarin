using EstadisticasFutbol.EntidadNegocio;
using EstadisticasFutbol.Utilerias;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EstadisticasFutbol.AccesoDatos
{
    public class DalEquipos
    {
        public async Task<Team> ObtenerEquipo(int pvn_IdEquipo)
        {
            EjecutorServiciosRest vlo_EjecutorServicioRest;
            List<HttpHeader> vlo_Encabezados;
            Team vlo_Resultado = null;

            try
            {
                vlo_EjecutorServicioRest = new EjecutorServiciosRest();
                vlo_Encabezados = new List<HttpHeader>();
                vlo_Encabezados.Add(new HttpHeader() { Name = Constantes.HEADER_AUTH_TOKEN, Value = Constantes.AUTH_TOKEN });
                vlo_Resultado = await vlo_EjecutorServicioRest.EjecutarGet<Team>(string.Format(Constantes.URL_API_TEAMS, pvn_IdEquipo), vlo_Encabezados);
            }
            catch (Exception)
            {
                throw;
            }

            return vlo_Resultado;
        }

    }
}
