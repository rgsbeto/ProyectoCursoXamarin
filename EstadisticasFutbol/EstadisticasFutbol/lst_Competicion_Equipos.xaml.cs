using EstadisticasFutbol.EntidadNegocio;
using EstadisticasFutbol.LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EstadisticasFutbol
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class lst_Competicion_Equipos : ContentPage
	{
        #region Propiedades
        public IList<object> Equipos { get; set; } = new ObservableCollection<object>();
        public Command RefreshCommand { get; set; }
        public BllCompeticiones BllCompeticiones { get; set; } = new BllCompeticiones();
        public Competition Competicion { get; set; }
        #endregion

        #region Constructores
        public lst_Competicion_Equipos(Competition pvo_Competicion)
        {
            BindingContext = this;
            Competicion = pvo_Competicion;
            RefreshCommand = new Command(() => lvCompeticionEquipos_OnRefresh());
            IsBusy = true;
            InitializeComponent();
            lvCompeticionEquipos.ItemSelected += lvCompeticionEquipos_OnItemSelected;
        }
        #endregion

        #region Eventos
        protected override void OnAppearing()
        {
            base.OnAppearing();
            lvCompeticionEquipos_OnRefresh();
        }

        protected async void lvCompeticionEquipos_OnRefresh()
        {
            if (!Plugin.Connectivity.CrossConnectivity.Current.IsConnected)
            {
                await DisplayAlert("Estadísticas Futbol", "No hay conexión a internet", "Aceptar");
                return;
            }

            try
            {
                IsBusy = true;
                var vlo_Equipos = await BllCompeticiones.ListarEquipos(Competicion.Id);
                Equipos.Clear();
                foreach (var Equipo in vlo_Equipos)
                {
                    Equipos.Add(Equipo);
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

        private void lvCompeticionEquipos_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new frm_Equipo((e.SelectedItem as Team)));
        }
        #endregion

        #region Metodos
        #endregion

        #region Funciones
        #endregion
    }
}