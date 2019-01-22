using EstadisticasFutbol.AccesoDatos;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace EstadisticasFutbol
{
    public partial class App : Application
    {
        private static DalDataCache _BaseDatos;

        public static DalDataCache BaseDatos
        {
            get
            {
                if (_BaseDatos == null)
                {
                    _BaseDatos = new DalDataCache(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "EstadisticasFutbol.db3"));
                }
                return _BaseDatos;
            }
        }

        public App()
        {
            InitializeComponent();
            
            MainPage = new NavigationPage(new lst_Competiciones());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
