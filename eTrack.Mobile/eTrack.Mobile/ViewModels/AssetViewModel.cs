using System.Windows.Input;
using eTrack.Mobile.Models;
using eTrack.Mobile.Views;
using Xamarin.Forms;

namespace eTrack.Mobile.ViewModels
{
    public class AssetViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }
        public ICommand AddCommand { get; protected set; }
        public AssetViewModel(INavigation navigation)
        {
            Title = "Datos del activo";
            this.Navigation = navigation;
            this.AddCommand = new Command(async () => await Navigation.PushAsync(new AltaActivoPage()));
        }
        public AssetViewModel()
        {
        }
        
        
        public Command EditCommand
        {
            get
            {
                //return new Command(() => { Application.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(new EditarPage())); });
                return new Command(() => { Navigation.PushAsync(new EditarPage()); });
            }
        }

        public Command FindCommand
        {
            get
            {
                return new Command(() => { Navigation.PushAsync(new BuscarPage()); }); 
            }
        }
        public Command DeleteCommand
        {
            get
            {
                return new Command(() => { Application.Current.MainPage.DisplayAlert("Eliminar", "Elimiar Activo", "Yes"); });
            }
        }
    }
}