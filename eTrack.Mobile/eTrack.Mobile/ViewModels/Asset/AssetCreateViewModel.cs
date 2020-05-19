using System.Collections.Generic;
using System.Windows.Input;
using Acr.UserDialogs;
using eTrack.Mobile.Models;
using eTrack.Mobile.Views;
using Xamarin.Forms;

namespace eTrack.Mobile.ViewModels.Asset
{
    public class AssetCreateViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }
        public ICommand BaseCommand { get; protected set; }

        private AssetModel _assetModel;

        public AssetModel AssetModel
        {
            get { return _assetModel; }
            set { _assetModel = value; OnPropertyChanged(); }
        }

        public AssetCreateViewModel(INavigation navigation)
        {
            Title = "Alta de activo";
            this.Navigation = navigation;
            LocationList = new List<string>() { "Norte", "Sur", "Este", "Oeste" };
            CostCenterList = new List<string>() { "Centro A", "Centro B", "Centro C" };
            _assetModel = new AssetModel()
            {
                FilePath = "icon_empty.png",
                Description = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam."
            };
            AssetModel = _assetModel;
        }
        public AssetCreateViewModel()
        {
        }
        public Command EditCommand
        {
            get
            {
                return new Command(() => { Navigation.PushAsync(new EditarPage()); });
            }
        }

        public Command SaveCommand
        {
            get
            {
                return new Command(() =>
                {
                    AddAsset();
                });
            }
        }

        private void AddAsset()
        {
            // Acceder a base de datos y guardar la información
            if (AssetModel.Code != null && AssetModel.Code != string.Empty)
                base.Message = "Info almacenada: Código " + AssetModel.Code + ", SapId " + AssetModel.SapId;
            UserDialogs.Instance.Alert("Info almacenada: Código " + AssetModel.Code + ", SapId " + AssetModel.SapId, "Guardar");
        }
    }
}