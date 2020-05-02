using eTrack.Mobile.Views;
using System.Windows.Input;
using Xamarin.Forms;

namespace eTrack.Mobile.ViewModels
{
    public class AsociarTagViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }
        public ICommand NavigationSearchAsset { get; protected set; }
        public ICommand NavigationConsultar { get; protected set; }
        public AsociarTagViewModel() { }

        public AsociarTagViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            this.NavigationSearchAsset = new Command(async () => await Navigation.PushAsync(new SearchAssetToAssociatePage()));
            this.NavigationConsultar = new Command(async () => await Navigation.PushAsync(new AssetInfoPage()));
        }
    }
}