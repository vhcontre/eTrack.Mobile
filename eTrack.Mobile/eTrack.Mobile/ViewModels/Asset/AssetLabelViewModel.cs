using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using eTrack.Mobile.Models;
using eTrack.Mobile.Views;
using Xamarin.Forms;

namespace eTrack.Mobile.ViewModels.Asset
{
    public class AssetLabelViewModel : BaseViewModel
    {
        private ObservableCollection<AssetLabelModel> _assetLabelModels;

        public INavigation Navigation { get; set; }
        //public ObservableCollection<AssetLabelModel> Items { get; set; }

        public ObservableCollection<AssetLabelModel> Items
        {
            get { return _assetLabelModels; }
            set
            {
                
                SetProperty(ref _assetLabelModels, value);
            }
        }
        public AssetLabelViewModel() { }
        public AssetLabelViewModel(INavigation navigation)
        {
            Title = "Etiquetas";
            this.Navigation = navigation;
            this.EmptyDataMessage = "No existen registros disponibles.";
            GetItemsAsync().ConfigureAwait(false);
            IsEmptyDataMessageVisible = (Items.Count <= 0);
        }


        public async Task GetItemsAsync()
        {
            IsBusy = true;
            try
            {
                Items = new ObservableCollection<AssetLabelModel>();
                for (int i = 5; i < 10; i++)
                {
                    Items.Add(new AssetLabelModel()
                    {
                        Id = i.ToString(),
                        Key = Guid.NewGuid().ToString().Substring(0, 5),
                        Value = Guid.NewGuid().ToString().Substring(0, 23),
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