using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eTrack.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AltaActivoPage : ContentPage
    {
        public AltaActivoPage()
        {
            InitializeComponent();
        }

        private void Save_Clicked(object sender, EventArgs e)
        {

        }

        private void Aceptar_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Guardar opción", "Se hizo clic en Guardar", "Botón 2", "Botón 1");
        }

        private void Cancelar_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Guardar Cancelar", "Se hizo clic en Cancelar", "Botón 2", "Botón 1");
        }
    }
}