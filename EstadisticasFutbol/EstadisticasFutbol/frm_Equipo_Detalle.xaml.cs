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
	public partial class frm_Equipo_Detalle : ContentPage
	{
        public Team Equipo { get; set; }

		public frm_Equipo_Detalle (Team pvo_Equipo)
		{
            Equipo = pvo_Equipo;
            BindingContext = Equipo;
            InitializeComponent ();
		}
	}
}