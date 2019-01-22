using EstadisticasFutbol.EntidadNegocio;
using EstadisticasFutbol.Utilerias;
using Newtonsoft.Json;
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
            DataCache vlo_Cache = null;
            string vlc_Url;

            try
            {
                vlc_Url = string.Format(Constantes.URL_API_TEAMS, pvn_IdEquipo);
                vlo_Cache = await App.BaseDatos.ObtenerCache(vlc_Url);
                if (vlo_Cache == null)
                {
                    vlo_EjecutorServicioRest = new EjecutorServiciosRest();
                    vlo_Encabezados = new List<HttpHeader>();
                    vlo_Encabezados.Add(new HttpHeader() { Name = Constantes.HEADER_AUTH_TOKEN, Value = Constantes.AUTH_TOKEN });
                    vlo_Resultado = await vlo_EjecutorServicioRest.EjecutarGet<Team>(vlc_Url, vlo_Encabezados);

                    vlo_Cache = new DataCache() { Url = vlc_Url, Expires = DateTime.Now.AddMinutes(Constantes.MINUTOS_VIGENCIA_CACHE), Data = JsonConvert.SerializeObject(vlo_Resultado) };
                    await App.BaseDatos.Salvar(vlo_Cache);
                }
                else
                {
                    vlo_Resultado = JsonConvert.DeserializeObject<Team>(vlo_Cache.Data, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, MissingMemberHandling = MissingMemberHandling.Ignore });
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
