using eTrack.Mobile.Services;
using eTrack.Mobile.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace eTrack.Mobile.ViewModels
{

    public class ResultadoHistorialViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }
        public ICommand EditCommand { get; protected set; }
        public ICommand DeleteCommand { get; protected set; }

        public ObservableCollection<AssetAuditModel> Items { get; set; }
        public Command LoadAssetsAuditCommand { get; set; }

        public ResultadoHistorialViewModel() { }

        public ResultadoHistorialViewModel(INavigation navigation)
        {
            Title = "Historial de auditorías";
            Items = new ObservableCollection<AssetAuditModel>();
            //this.LoadAssetsAuditCommand = new Command(async () => await ExecuteLoadItemsCommand());
            _ = ExecuteLoadItemsCommand();

            this.Navigation = navigation;
            this.EditCommand = new Command(async () => await SaveCommand());
            this.DeleteCommand = new Command(async () => await Application.Current.MainPage.DisplayAlert("Eliminar", "Se hizo clic en eliminar", "Ok"));
        }
        private static async Task SaveCommand()
        {
            await Application.Current.MainPage.DisplayAlert("Command Aceptar", "Se hizo clic en Aceptar", "Yes", "No");
        }
        private async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await AssetAuditDb.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
    public class AuditoriaViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }
        public ICommand NavigationPage { get; protected set; }
        public ICommand ResultadoHistorialPageCommand { get; protected set; }
        public ICommand BuscarPageCommand { get; protected set; }
        public AuditoriaViewModel() { }

        public AuditoriaViewModel(INavigation navigation)
        {
            Title = "Auditoria";
            this.Navigation = navigation;
            this.NavigationPage = new Command(async () => await Navigation.PushAsync(new AuditarPage()));

            //this.ResultadoHistorialPageCommand = new Command(async () => await Navigation.PushAsync(new ResultadoHistorialPage()));
            this.ResultadoHistorialPageCommand = new Command(() =>
            {
                Application.Current.MainPage.Navigation.PushAsync(new ResultadoHistorialTabbedPage());
            });
            //new Command(async () => 
            //await Navigation.PushAsync(new ResultadoHistorialTabbedPage()));




            //Application.Current.MainPag 
            this.BuscarPageCommand = new Command(async () => await Navigation.PushAsync(new BuscarPage()));
            //BuscarPageCommand
        }
    }
}