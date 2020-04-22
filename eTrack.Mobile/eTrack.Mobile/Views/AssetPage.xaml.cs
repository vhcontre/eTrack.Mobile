using eTrack.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eTrack.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AssetPage : ContentPage
    {
        AssetViewModel viewModel;
        public AssetPage(AssetViewModel viewModel)
        {
            InitializeComponent();
            //BindingContext = viewModel = new AssetViewModel();
            BindingContext = this.viewModel = viewModel;
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://xamarin.com"));
        }

        private void Save_Clicked(object sender, EventArgs e)
        {

        }
        async void AltaActivoPage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AltaActivoPage());
        }
        public ICommand OpenWebCommand { get; }

        async void Editar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditarPage());
        }

        async void Buscar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BuscarPage());
        }

        private void Borrar_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Guardar borrar", "Se hizo clic en borrar", "aceptar", "cancelar");
        }

        private void Salir_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Salir", "Opción salir del módulo", "aceptar");
        }

        private void T_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Teclado", "Se hizo clic en Teclado", "aceptar");
        }

        private void Ver_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Vista", "Se hizo clic en Ver", "aceptar");
        }
    }
}