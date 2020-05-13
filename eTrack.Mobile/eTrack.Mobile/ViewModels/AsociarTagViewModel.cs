using eTrack.Mobile.Views;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace eTrack.Mobile.ViewModels
{

    public class AssetInfoViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }
        public ICommand NavigationSearchAsset { get; protected set; }
        public ICommand OkCommand { get; protected set; }
        public AssetInfoViewModel() { }

        public AssetInfoViewModel(INavigation navigation)
        {
            Title = "Información consulta TAG";
            this.Navigation = navigation;
            //this.NavigationSearchAsset = new Command(async () => await Navigation.PushAsync(new SearchAssetToAssociatePage()));
            //this.NavigationConsultar = new Command(async () => await Navigation.PushAsync(new AssetInfoPage()));

            this.OkCommand = new Command(() =>
            {
                Application.Current.MainPage.DisplayAlert("Información consulta", "Ok", "Yes");
            });
        }
    }
    public class SearchAssetToAssociateViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }
        public SearchAssetToAssociateViewModel() { }

        public SearchAssetToAssociateViewModel(INavigation navigation)
        {
            Title = "Búsquedas de activos";
            this.Navigation = navigation;
            this.SearchArgumentList = new List<string>() { "Tag", "Código", "Fecha de alta" };
            this.SearchArgumentFilters = new List<string>() { "Menor igual", "Mayor igual", "Igual", "Contiene", "Todos" };
        }
        public Command FindCommand
        {
            get
            {
                return new Command(() => {
                    Application.Current.MainPage.DisplayAlert("Buscar", this.SelectedItem + " - " + this.SelectedFilter, "Yes");
                    Navigation.PushAsync(new ResultadoBusquedaPage());
                });
            }
        }
    }
    public class AsociarTagViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }
        public ICommand NavigationSearchAsset { get; protected set; }
        public ICommand NavigationConsultar { get; protected set; }
        public AsociarTagViewModel() { }

        public AsociarTagViewModel(INavigation navigation)
        {
            Title = "Asociación de TAG";
            this.Navigation = navigation;
            this.NavigationSearchAsset = new Command(async () => await Navigation.PushAsync(new SearchAssetToAssociatePage()));
            this.NavigationConsultar = new Command(async () => await Navigation.PushAsync(new AssetInfoPage()));
        }
    }
}