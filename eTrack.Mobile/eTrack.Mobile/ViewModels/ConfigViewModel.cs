using eTrack.Mobile.Views;
using System.Windows.Input;
using Xamarin.Forms;

namespace eTrack.Mobile.ViewModels
{
    public class ConfigViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }
        public ICommand NavigationPage { get; protected set; }
        public ConfigViewModel() { }

        public ConfigViewModel(INavigation navigation)
        {
            this.Title = "Configuración";
            this.Navigation = navigation;
            this.NavigationPage = new Command(async () => await Navigation.PushAsync(new AboutPage()));
        }

        public Command AcceptCommand
        {
            get
            {
                return new Command(() =>
                {
                    //Navigation.PushModalAsync(new NavigationPage(new LoginPage()));
                    //Navigation.PushModalAsync(new LoginPage());
                    Navigation.PushAsync(new LoginPage());
                });
            }
        }
        
    }
}