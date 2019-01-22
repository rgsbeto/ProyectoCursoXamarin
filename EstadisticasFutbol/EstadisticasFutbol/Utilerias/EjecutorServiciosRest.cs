using EstadisticasFutbol.EntidadNegocio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EstadisticasFutbol.Utilerias
{
    public class EjecutorServiciosRest
    {
        public async Task<T> EjecutarGet<T>(string pvc_UrlServicio, List<HttpHeader> pvo_EncabezadosHttp) where T : class, new()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(pvc_UrlServicio))
                {
                    throw new ArgumentNullException("pvc_UrlServicio");
                }

                using (var vlo_ClienteHttp = new HttpClient())
                {
                    vlo_ClienteHttp.BaseAddress = new Uri(pvc_UrlServicio);
                    vlo_ClienteHttp.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Constantes.MIME_TYPE_JSON));
                    if (pvo_EncabezadosHttp != null && pvo_EncabezadosHttp.Count > 0)
                    {
                        foreach (var vlo_Encabezado in pvo_EncabezadosHttp)
                        {
                            vlo_ClienteHttp.DefaultRequestHeaders.Add(vlo_Encabezado.Name, vlo_Encabezado.Value);
                        }
                    }
                    var vlc_RespuestaHttp = await vlo_ClienteHttp.GetStringAsync(string.Empty);

                    if (!string.IsNullOrWhiteSpace(vlc_RespuestaHttp))
                    {
                        var vlo_JsonSerializerSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, MissingMemberHandling = MissingMemberHandling.Ignore };
                        var vlo_Resultado = JsonConvert.DeserializeObject<T>(vlc_RespuestaHttp,vlo_JsonSerializerSettings);
                        return vlo_Resultado;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return null;
        }
    }
}
