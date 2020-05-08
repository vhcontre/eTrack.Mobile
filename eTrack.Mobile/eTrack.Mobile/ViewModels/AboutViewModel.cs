using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace eTrack.Mobile.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel(INavigation navigation)
        {
            Title = "Información - eFALCOM S.A";
        }
        public AboutViewModel() { }
    }
}