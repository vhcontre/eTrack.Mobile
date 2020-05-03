using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace eTrack.Mobile.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "Información - eFALCOM S.A";
        }
        public Command CloseCommand
        {
            get
            {
                return new Command(() =>
                {
                    Application.Current.MainPage.Navigation.PopToRootAsync();
                });
            }
        }
    }
}