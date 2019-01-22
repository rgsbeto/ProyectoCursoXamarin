using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EstadisticasFutbol.EntidadNegocio;
using SQLite;

namespace EstadisticasFutbol.AccesoDatos
{
    public class DalDataCache
    {
        #region Atributos
        private readonly SQLiteAsyncConnection ConexionBaseDatos;
        #endregion

        #region Constructores
        public DalDataCache(string pvc_RutaBaseDatos)
        {
            ConexionBaseDatos = new SQLiteAsyncConnection(pvc_RutaBaseDatos);
            ConexionBaseDatos.CreateTableAsync<DataCache>().Wait();
        }
        #endregion

        #region Funciones
        public async Task<DataCache> ObtenerCache(string pvc_Url)
        {
            return await ConexionBaseDatos.Table<DataCache>().Where(vlo_Data => vlo_Data.Url == pvc_Url && vlo_Data.Expires > DateTime.Now).FirstOrDefaultAsync();
        }

        //public async Task<Boolean> ExisteCache(string pvc_Url)
        //{
        //    return await ConexionBaseDatos.Table<DataCache>().Where(vlo_Data => vlo_Data.Url == pvc_Url).FirstOrDefaultAsync() != null;
        //}

        public async Task<int> Salvar(DataCache pvo_Cache)
        {
            await ConexionBaseDatos.DeleteAsync(pvo_Cache);
            return await ConexionBaseDatos.InsertAsync(pvo_Cache);


            //if (await ExisteCache(pvo_Cache.Url))
            //{
            //    return await ConexionBaseDatos.UpdateAsync(pvo_Cache);
            //}
            //else
            //{
            //    return await ConexionBaseDatos.InsertAsync(pvo_Cache);
            //}
        }
        #endregion
    }
}
