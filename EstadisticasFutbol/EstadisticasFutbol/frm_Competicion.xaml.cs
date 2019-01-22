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
	public partial class frm_Competicion : TabbedPage
    {
        public Competition Competicion { get; set; }

		public frm_Competicion (Competition pvo_Competicion)
		{
            Competicion = pvo_Competicion;
			InitializeComponent ();
            this.Title = Competicion.Name;
            this.Children.Add(new lst_Competicion_Equipos(Competicion));
            this.Children.Add(new lst_Competicion_Estadisticas(Competicion));
        }
	}
}