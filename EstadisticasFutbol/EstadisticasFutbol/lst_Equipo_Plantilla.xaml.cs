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
    public partial class lst_Equipo_Plantilla : ContentPage
    {

        #region Propiedades
        public int IdEquipo { get; set; }
        public IList<object> Plantilla { get; set; } = new ObservableCollection<object>();
        public Command RefreshCommand { get; set; }
        public BllEquipos BllEquipos { get; set; } = new BllEquipos();

        #endregion

        #region Constructores
        public lst_Equipo_Plantilla(int pvn_IdEquipo)
        {
            IdEquipo = pvn_IdEquipo;
            BindingContext = this;
            RefreshCommand = new Command(() => lvEquipoPlantilla_OnRefresh());
            IsBusy = true;
            InitializeComponent();
        }
        #endregion

        #region Eventos
        protected override void OnAppearing()
        {
            base.OnAppearing();
            lvEquipoPlantilla_OnRefresh();
        }

        protected async void lvEquipoPlantilla_OnRefresh()
        {
            if (!Plugin.Connectivity.CrossConnectivity.Current.IsConnected)
            {
                await DisplayAlert("Estadísticas Futbol", "No hay conexión a internet", "Aceptar");
                return;
            }

            try
            {
                IsBusy = true;
                var vlo_Plantilla = await BllEquipos.ListarPlantilla(IdEquipo);
                Plantilla.Clear();
                foreach (var Jugador in vlo_Plantilla)
                {
                    if (Jugador.Role == "PLAYER")
                    {
                        Plantilla.Add(Jugador);
                    }
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