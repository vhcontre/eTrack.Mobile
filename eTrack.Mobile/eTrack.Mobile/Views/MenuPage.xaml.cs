using eTrack.Mobile.Models;
using eTrack.Mobile.ViewModels;
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
    public partial class MenuPage : ContentPage
    {
        ItemsViewModel viewModel;
        public MenuPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ItemsViewModel();
        }
        async void OnItemSelected(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var item = (Item)layout.BindingContext;

            switch (item.Id)
            {
                case "ABM":
                    await Navigation.PushAsync(new AssetPage());
                    break;
                case "AsociarTAG":
                    await Navigation.PushAsync(new AsociarTagPage());
                    break;
                case "Inventariar":
                    await Navigation.PushAsync(new PreparacionInventarioPage());
                    break;
                case "Localizar":
                    await Navigation.PushAsync(new BuscarPage());
                    break;
                case "Auditar":
                    await Navigation.PushAsync(new AuditoriaPage());
                    break;
                case "Reportes":
                    await Navigation.PushAsync(new ReportesPage());
                    break;
                case "Setting":
                    await Navigation.PushAsync(new ConfigPage());
                    break;
                default:
                    break;
            }
        }
        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();

        //    if (viewModel.Items.Count == 0)
        //        viewModel.IsBusy = true;
        //}
    }
}