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
	public partial class lst_Competicion_Estadisticas : ContentPage
	{
        #region Propiedades
        public IList<object> Estadisticas { get; set; } = new ObservableCollection<object>();
        public Command RefreshCommand { get; set; }
        public BllCompeticiones BllCompeticiones { get; set; } = new BllCompeticiones();
        public Competition Competicion { get; set; }
        #endregion

        #region Constructores
        public lst_Competicion_Estadisticas(Competition pvo_Competicion)
        {
            BindingContext = this;
            Competicion = pvo_Competicion;
            RefreshCommand = new Command(() => lvCompeticionEstadisticas_OnRefresh());
            IsBusy = true;
            InitializeComponent();
            lvCompeticionEstadisticas.ItemSelected += lvCompeticionEstadisticas_OnItemSelected;
        }
        #endregion

        #region Eventos
        protected override void OnAppearing()
        {
            base.OnAppearing();
            lvCompeticionEstadisticas_OnRefresh();
        }

        protected async void lvCompeticionEstadisticas_OnRefresh()
        {
            if (!Plugin.Connectivity.CrossConnectivity.Current.IsConnected)
            {
                await DisplayAlert("Estadísticas Futbol", "No hay conexión a internet", "Aceptar");
                return;
            }

            try
            {
                IsBusy = true;
                var vlo_Estadisticas = await BllCompeticiones.ListarEstadisticas(Competicion.Id);
                Estadisticas.Clear();
                foreach (var Estadistica in vlo_Estadisticas)
                {
                    Estadisticas.Add(Estadistica);
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

        private void lvCompeticionEstadisticas_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new lst_Competicion_Estadisticas_Partidos(Competicion, (e.SelectedItem as Table).Team));
        }
        #endregion
    }
}