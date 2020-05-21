using Acr.UserDialogs;
using eTrack.Mobile.Models;
using eTrack.Mobile.Services;
using eTrack.Mobile.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eTrack.Mobile.ViewModels
{
    //InventarioNotasPage
    public class InventarioNotasViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }
        public InventarioNotasViewModel(INavigation navigation)
        {
            Title = "Inventario - Notas";
            this.Navigation = navigation;
        }
        public InventarioNotasViewModel() { }

        public Command SaveCommand
        {
            get
            {
                return new Command(() =>
                {
                    Save();
                });
            }

        }
        private void Save()
        {
            // Acceder a base de datos y guardar la información
            Application.Current.MainPage.DisplayAlert("Guardar", "Guardar notas", "Yes");
        }
    }
    public class PreparacionInventarioViewModel : BaseViewModel
    {
        public ObservableCollection<AssetModel> Items { get; set; }
        public INavigation Navigation { get; protected set; }
        public PreparacionInventarioViewModel(INavigation navigation)
        {
            Title = "Inventario - Preparación";
            this.Navigation = navigation;
            Items = new ObservableCollection<AssetModel>();
            LocationList = new List<string>() { "Location-Norte", "Location-Sur", "Location-Este", "Location-Oeste", "Todos" };
            CostCenterList = new List<string>() { "Centro A", "Centro B", "Centro C", "Todos" };
            IsBusy = false;
        }
        public PreparacionInventarioViewModel() { }
        public ICommand InventoryCommand => new Command(async () => { await Navigation.PushAsync(new InventarioPage()); });

        public ICommand StartCommand => new Command(async () => { await StartProcess(); });
        private async Task StartProcess()
        {
            // Acceder a base de datos y guardar la información
            await UserDialogs.Instance.AlertAsync("Inicio del proceso de Inventario", "Proceso de Inventario");
        }


        public ICommand FilterCommand => new Command<object>(async (parameter) => await OnLoadItemsCommand(parameter));
        private async Task OnLoadItemsCommand(object parameter = null)
        {
            IsBusy = true;
            try
            {
                Items.Clear();
                //var AssetDb = DependencyService.Get<IDataStore<AssetModel>>();
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
}