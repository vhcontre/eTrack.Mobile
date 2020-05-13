using Acr.UserDialogs;
using eTrack.Mobile.Models;
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
    public class ResultadoBusquedaViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }
        public ObservableCollection<AssetModel> Items { get; set; }
        public Command LoadAssetsCommand { get; set; }

        public ResultadoBusquedaViewModel() { }

        public ResultadoBusquedaViewModel(INavigation navigation)
        {
            Title = "Resultado de la búsqueda";
            Items = new ObservableCollection<AssetModel>();
            this.Navigation = navigation;
            OnLoadItemsCommand().ConfigureAwait(false);

        }
        private async Task OnLoadItemsCommand()
        {
            IsBusy = true;
            try
            {
                Items.Clear();
                var AssetDb = DependencyService.Get<IDataStore<AssetModel>>();
                var items = await AssetDb.GetItemsAsync(true);
                foreach (var item in items)
                    Items.Add(item);
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
    public class ResultadoHistorialViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }
        public ObservableCollection<AssetAuditModel> Items { get; set; }
        public Command LoadAssetsAuditCommand { get; set; }

        public ResultadoHistorialViewModel() { }

        public ResultadoHistorialViewModel(INavigation navigation)
        {
            Title = "Historial de auditorías";
            Items = new ObservableCollection<AssetAuditModel>();
            this.Navigation = navigation;
            OnLoadItemsCommand().ConfigureAwait(false);

        }
        public ICommand EditCommand
        {
            get
            {
                return new Command<string>((parameter) => OnSaveCommand(parameter));
            }
        }
        public ICommand DeleteCommand
        {
            get
            {
                return new Command<string>((parameter) => OnRemoveCommand(parameter));
            }
        }
        private void OnSaveCommand(string parameter)
        {
            Application.Current.MainPage.DisplayAlert("Editar auditoria", parameter, "Ok");
        }
        private async void OnRemoveCommand(string parameter)
        {
            var result = await UserDialogs.Instance.ConfirmAsync(string.Format(UserMessageResources.AssetAuditDeleteConfirmation, parameter), "Eliminar", "Si", "No");
            if (result)
                await Application.Current.MainPage.DisplayAlert("Auditoria Eliminada", parameter, "Ok");

        }
        private async Task OnLoadItemsCommand()
        {
            IsBusy = true;
            try
            {
                Items.Clear();
                var items = await AssetAuditDb.GetItemsAsync(true);
                foreach (var item in items)
                    Items.Add(item);
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
            this.ResultadoHistorialPageCommand = new Command(async () => await Navigation.PushAsync(new ResultadoHistorialPage()));
            this.BuscarPageCommand = new Command(async () => await Navigation.PushAsync(new BuscarPage()));
        }
    }
}