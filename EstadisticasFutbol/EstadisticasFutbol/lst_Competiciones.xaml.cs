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
    public partial class lst_Competiciones : ContentPage
    {
        #region Propiedades
        public IList<object> Competiciones { get; set; } = new ObservableCollection<object>();
        public Command RefreshCommand { get; set; }
        public BllCompeticiones BllCompeticiones { get; set; } = new BllCompeticiones();
        #endregion

        #region Constructores
        public lst_Competiciones()
        {
            BindingContext = this;
            RefreshCommand = new Command(() => lvCompeticiones_OnRefresh());
            IsBusy = true;
            InitializeComponent();
            lvCompeticiones.ItemSelected += lvCompeticiones_OnItemSelected;
        }
        #endregion

        #region Eventos
        protected override void OnAppearing()
        {
            base.OnAppearing();
            lvCompeticiones_OnRefresh();
        }

        protected async void lvCompeticiones_OnRefresh()
        {
            if (!Plugin.Connectivity.CrossConnectivity.Current.IsConnected)
            {
                await DisplayAlert("Estadísticas Futbol", "No hay conexión a internet", "Aceptar");
                return;
            }

            try
            {
                IsBusy = true;
                var vlo_Competiciones = await BllCompeticiones.ListarCompeticiones();
                Competiciones.Clear();
                foreach (var Competicion in vlo_Competiciones)
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

        private void lvCompeticiones_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new frm_Competicion((e.SelectedItem as Competition)));
        }

        #endregion

        #region Metodos
        #endregion

        #region Funciones
        #endregion
    }
}