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
    public partial class InventarioPage : ContentPage
    {
        public InventarioPage()
        {
            InitializeComponent();
        }

        private void Exportar_Clicked(object sender, EventArgs e)
        {

        }

        private void Cancelar_Clicked(object sender, EventArgs e)
        {

        }

        async void Notas_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InventarioNotasPage());
        }
    }
}