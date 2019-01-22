using EstadisticasFutbol.AccesoDatos;
using EstadisticasFutbol.EntidadNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EstadisticasFutbol
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class frm_Equipo : TabbedPage
	{
        public Team Equipo { get; set; }

        public frm_Equipo (Team pvo_Equipo)
		{
            this.Equipo = pvo_Equipo;
            InitializeComponent();
            this.Title = Equipo.Name;
            this.Children.Add(new frm_Equipo_Detalle(Equipo));
            this.Children.Add(new lst_Equipo_Plantilla(Equipo.Id));
            this.Children.Add(new lst_Equipo_Competiciones(Equipo.Id));
        }
    }
}