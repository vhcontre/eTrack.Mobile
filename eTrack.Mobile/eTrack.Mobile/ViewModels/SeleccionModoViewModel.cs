using eTrack.Mobile.Views;
using System.Windows.Input;
using Xamarin.Forms;

namespace eTrack.Mobile.ViewModels
{
    //SeleccionModo
    public class SeleccionModoViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }
        //public ICommand NavigationLogin { get; protected set; }
        public SeleccionModoViewModel()
        {
        }

        public SeleccionModoViewModel(INavigation navigation)
        {

            this.Title = "Selección de modo";
            this.Navigation = navigation;
            //this.NavigationLogin = new Command(async () => await Navigation.PushAsync(new LoginPage()));
        }

        public Command NavigationLogin
        {
            get
            {
                return new Command(() =>
                {
                    //Navigation.PushAsync(new NavigationPage(new LoginPage()));
                    Navigation.PushAsync(new LoginPage());
                });
            }
        }

    }
}