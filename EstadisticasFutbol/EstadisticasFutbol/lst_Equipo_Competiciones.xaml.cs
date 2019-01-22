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
	public partial class lst_Equipo_Competiciones : ContentPage
	{
        #region Propiedades
        public int IdEquipo { get; set; }
        public IList<object> Competiciones { get; set; } = new ObservableCollection<object>();
        public Command RefreshCommand { get; set; }
        public BllEquipos BllEquipos { get; set; } = new BllEquipos();
        #endregion

        #region Constructores
        public lst_Equipo_Competiciones(int pvn_IdEquipo)
        {
            IdEquipo = pvn_IdEquipo;
            BindingContext = this;
            RefreshCommand = new Command(() => lvEquipoCompeticiones_OnRefresh());
            IsBusy = true;
            InitializeComponent();
        }
        #endregion

        #region Eventos
        protected override void OnAppearing()
        {
            base.OnAppearing();
            lvEquipoCompeticiones_OnRefresh();
        }

        protected async void lvEquipoCompeticiones_OnRefresh()
        {
            if (!Plugin.Connectivity.CrossConnectivity.Current.IsConnected)
            {
                await DisplayAlert("Estadísticas Futbol", "No hay conexión a internet", "Aceptar");
                return;
            }

            try
            {
                IsBusy = true;
                var vlo_CompeticionesActivas = await BllEquipos.ListarCompeticionesActivas(IdEquipo);
                Competiciones.Clear();
                foreach (var Competicion in vlo_CompeticionesActivas)
                {
                    Competiciones.Add(Competicion);
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