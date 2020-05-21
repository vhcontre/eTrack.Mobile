using eTrack.Mobile.Models;
using eTrack.Mobile.Services;
using eTrack.Mobile.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eTrack.Mobile.ViewModels
{

    public class InventarioViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }
        public ObservableCollection<AssetModel> Items { get; set; }
        public InventarioViewModel() { }
        public InventarioViewModel(INavigation navigation)
        {
            Title = "Inventario - Ejecución";
            this.Navigation = navigation;
            Items = new ObservableCollection<AssetModel>();
            OnLoadItemsCommand(null).ConfigureAwait(false);
            IsBusy = false;
        }

        public ICommand NoteCommand => new Command(() => { Navigation.PushAsync(new InventarioNotasPage()); });
        public ICommand StartCommand => new Command(() => { StartProcess(); });

        private void StartProcess()
        {
            // Acceder a base de datos y guardar la información
            Application.Current.MainPage.DisplayAlert("Comenzar", "Iniciar proceso", "Yes");
        }
        //public ICommand FilterCommand => new Command<object>(async (parameter) => await OnLoadItemsCommand(parameter));
        private async Task OnLoadItemsCommand(object parameter = null)
        {
            IsBusy = true;
            try
            {
                Items.Clear();
                var AssetDb = DependencyService.Get<IDataStore<AssetModel>>();
                var items = await AssetDb.GetItemsAsync();
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
}