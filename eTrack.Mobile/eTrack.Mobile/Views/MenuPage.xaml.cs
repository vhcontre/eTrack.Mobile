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

            if (item.Id == "ABM")
            {
                await Navigation.PushAsync(new AssetPage(new AssetViewModel()));
            }

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.IsBusy = true;
        }
    }
}