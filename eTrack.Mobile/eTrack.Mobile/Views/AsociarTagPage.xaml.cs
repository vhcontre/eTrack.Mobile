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
    public partial class AsociarTagPage : ContentPage
    {
        public AsociarTagPage()
        {
            InitializeComponent();
        }

        private void Salir_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Salir", "Se hizo clic en Salir", "aceptar");
        }
    }
}