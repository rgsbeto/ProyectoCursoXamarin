using EstadisticasFutbol.EntidadNegocio;
using EstadisticasFutbol.LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EstadisticasFutbol
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class lst_Competicion_Estadisticas_Partidos : ContentPage
    {
        #region Propiedades
        public IList<object> Partidos { get; set; } = new ObservableCollection<object>();
        public Command RefreshCommand { get; set; }
        public BllCompeticiones BllCompeticiones { get; set; } = new BllCompeticiones();
        public Competition Competicion { get; set; }
        public Team Equipo { get; set; }
        #endregion

        #region Constructores
        public lst_Competicion_Estadisticas_Partidos(Competition pvo_Competicion, Team pvo_Equipo)
        {
            BindingContext = this;
            Competicion = pvo_Competicion;
            Equipo = pvo_Equipo;
            RefreshCommand = new Command(() => lvCompeticionEstadisticasPartidos_OnRefresh());
            IsBusy = true;
            InitializeComponent();
            this.Title = $"{Equipo.Name} - Partidos";
        }
        #endregion

        #region Eventos
        protected override void OnAppearing()
        {
            base.OnAppearing();
            lvCompeticionEstadisticasPartidos_OnRefresh();
        }

        protected async void lvCompeticionEstadisticasPartidos_OnRefresh()
        {
            if (!Plugin.Connectivity.CrossConnectivity.Current.IsConnected)
            {
                await DisplayAlert("Estadísticas Futbol", "No hay conexión a internet", "Aceptar");
                return;
            }

            try
            {
                IsBusy = true;
                var vlo_Partidos = await BllCompeticiones.ListarPartidos(Competicion.Id, Equipo.Id);
                Partidos.Clear();
                foreach (var Partido in vlo_Partidos)
                {
                    Partidos.Add(Partido);
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Estadísticas Futbol", ex.Message, "Aceptar");
            }
            finally
            {
                IsBusy = false;
            }
        }
        #endregion
    }
}