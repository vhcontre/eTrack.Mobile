using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using eTrack.Mobile.Models;
using eTrack.Mobile.Views;
using eTrack.Mobile.Views.Popups;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace eTrack.Mobile.ViewModels.Asset
{
    public class AssetActionViewModel : BaseViewModel
    {
        private ObservableCollection<AssetActionModel> _assetActionModels;

        public INavigation Navigation { get; set; }

        public ObservableCollection<AssetActionModel> Items
        {
            get { return _assetActionModels; }
            set
            {

                SetProperty(ref _assetActionModels, value);
            }
        }
        public AssetActionViewModel() { }
        public AssetActionViewModel(INavigation navigation, bool isActionMenu = false)
        {
            Title = "Acciones";
            this.Navigation = navigation;
            this.EmptyDataMessage = "No existen registros disponibles.";
            AcceptCommand = new Command(execute: OnAcceptCommand);
            CancelCommand = new Command(execute: OnCancelCommand);
            if(isActionMenu)
                GetItemsMenuAsync().ConfigureAwait(false); 
            else
                GetItemsAsync().ConfigureAwait(false);

            IsEmptyDataMessageVisible = (Items.Count <= 0);
        }

        public ICommand ExecuteCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await PopupNavigation.Instance.PushAsync(new ExecutePage());
                });
            }
        }
        public ICommand AcceptCommand { get; internal set; }
        public ICommand CancelCommand { get; internal set; }

        

        private async void OnCancelCommand(object obj)
        {
            await PopupNavigation.Instance.PopAsync(true);
        }

        private async void OnAcceptCommand(object obj)
        {

            await PopupNavigation.Instance.PopAsync(true);
        }
        public async Task GetItemsAsync()
        {
            IsBusy = true;
            try
            {
                Items = new ObservableCollection<AssetActionModel>();
                for (int i = 5; i < 10; i++)
                {
                    Items.Add(new AssetActionModel()
                    {
                        Id = i.ToString(),
                        Name = Guid.NewGuid().ToString().Substring(0, 5),
                        Description = Guid.NewGuid().ToString().Substring(0, 23),
                        Status = true,
                        DateExecute = DateTime.Now,
                    });
                };
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
            await Task.Delay(0);
        }
        public async Task GetItemsMenuAsync()
        {
            IsBusy = true;
            try
            {
                Items = new ObservableCollection<AssetActionModel>();
                for (int i = 1; i < 10; i++)
                {
                    Items.Add(new AssetActionModel()
                    {
                        Id = i.ToString(),
                        Name = Guid.NewGuid().ToString().Substring(0, 5),
                        Description = Guid.NewGuid().ToString().Substring(0, 23),
                        Status = true,
                        DateExecute = DateTime.Now,
                    });
                };
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
            await Task.Delay(0);
        }

    }
}