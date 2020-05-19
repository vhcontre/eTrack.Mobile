using System;
using System.Collections.Generic;
using eTrack.Mobile.Models;
using Xamarin.Forms;

namespace eTrack.Mobile.ViewModels.Asset
{
    public class AssetEditViewModel : BaseViewModel
    {

        public string TagIdActual { get; set; }
        public AssetEditViewModel()
        {
        }
        public INavigation Navigation { get; set; }

        private AssetModel _assetModel;

        public AssetModel AssetModel
        {
            get { return _assetModel; }
            set { _assetModel = value; OnPropertyChanged(); }
        }

        public AssetEditViewModel(INavigation navigation)
        {
            Title = "Edición del activo";
            this.Navigation = navigation;
            LocationList = new List<string>() { "Norte", "Sur", "Este", "Oeste" };
            CostCenterList = new List<string>() { "Centro A", "Centro B", "Centro C" };
            _assetModel = new AssetModel()
            {
                Tag = string.Format("TagId Actual: {0}", Guid.NewGuid().ToString().Substring(0, 12)),
                SapId = string.Format("SapId: {0}", "145"),
                Code = "Código: " + Guid.NewGuid().ToString().Substring(0, 5),
                FilePath = "icon_auditar.png",
                Location = string.Format("Ubicación {0}", "Norte"),
                CostCenterName = "Centro Costo",
                CreatedBy = "User Created",
                Description = "Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem. Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur?.",
                LastModifiedBy = "User Modified"
            };
            TagIdActual = _assetModel.Tag;
            _assetModel.Tag = string.Empty;
            AssetModel = _assetModel;
        }

        public Command EditCommand
        {
            get
            {
                return new Command(() =>
                {

                    EditAsset();
                });
            }
        }
        private void EditAsset()
        {
            // Acceder a base de datos y guardar la información
            if (AssetModel.Code != null && AssetModel.Code != string.Empty)
                base.Message = "Info editada: Código " + AssetModel.Code + ", SapId " + AssetModel.SapId;
            var data = this.LocationSelectedItem + " - " + this.CostCenterSelectedItem;
            Application.Current.MainPage.DisplayAlert("Listas", data, "Ok");
        }
    }
}