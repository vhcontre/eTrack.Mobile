using eTrack.Mobile.Views;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace eTrack.Mobile.ViewModels
{
    public class AuditoriaViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }
        public ICommand NavigationPage { get; protected set; }
        public AuditoriaViewModel() { }

        public AuditoriaViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            this.NavigationPage = new Command(async () => await Navigation.PushAsync(new AuditarPage()));
        }
    }
}