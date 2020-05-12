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
            DependencyService.Register<AssetAuditService>();
            DependencyService.Register<AssetService>();
            //MainPage = new MainPage();
            //MainPage = new NavigationPage(new SeleccionModoPage());
            MainPage = new NavigationPage(new MenuPage());
            //MainPage = new NavigationPage(new LoginPage());

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
