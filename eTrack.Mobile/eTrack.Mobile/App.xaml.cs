using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using eTrack.Mobile.Services;
using eTrack.Mobile.Views;

namespace eTrack.Mobile
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            //MainPage = new MainPage();
            MainPage = new NavigationPage(new SeleccionModoPage());

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
        
    }
}
