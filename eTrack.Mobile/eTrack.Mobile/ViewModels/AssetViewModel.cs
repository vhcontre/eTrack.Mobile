using System;
using System.Collections.Generic;
using System.Windows.Input;
using Acr.UserDialogs;
using eTrack.Mobile.Models;
using eTrack.Mobile.Views;
using Xamarin.Forms;

namespace eTrack.Mobile.ViewModels
{
    public class AssetViewModel : BaseViewModel
    {
        private AssetModel _assetModel;
        public AssetModel AssetModel
        {
            get { return _assetModel; }
            set { _assetModel = value; OnPropertyChanged(); }
        }
        public INavigation Navigation { get; set; }
        public ICommand AddCommand { get; protected set; }
        public AssetViewModel(INavigation navigation)
        {
            Title = "Datos del activo";
            this.Navigation = navigation;
            this.AddCommand = new Command(async () => await Navigation.PushAsync(new AltaActivoPage()));

            _assetModel = new AssetModel()
            {
                Tag = string.Format("TagId: {0}", Guid.NewGuid().ToString().Substring(0, 12)),
                SapId = string.Format("SapId: {0}", "145"),
                Code = "Código: " + Guid.NewGuid().ToString().Substring(0, 5),
                FilePath = "icon_auditar.png",
                Location = string.Format("Ubicación {0}", "Moreno"),
                CostCenterName = "Centro Costo",
                CreatedBy = "User Created",
                Description = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam.",
                LastModifiedBy = "User Modified"

            };
            AssetModel = _assetModel;
        }
        public AssetViewModel()
        {
        }
        public Command EditCommand
        {
            get
            {
                //return new Command(() => { Application.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(new EditarPage())); });
                return new Command(() => { Navigation.PushAsync(new EditarPage()); });
            }
        }
        public Command FindCommand
        {
            get
            {
                return new Command(() => { Navigation.PushAsync(new BuscarPage()); });
            }
        }
        public Command DeleteCommand
        {
            get
            {
                return new Command(() => { Application.Current.MainPage.DisplayAlert("Eliminar", "Elimiar Activo", "Yes"); });
            }
        }
    }

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

    public class AssetFindViewModel : BaseViewModel
    {
        public AssetFindViewModel()
        {
        }
        public INavigation Navigation { get; set; }

        public AssetFindViewModel(INavigation navigation)
        {
            Title = "Búsqueda de activo";
            this.Navigation = navigation;
            this.SearchArgumentList = new List<string>() { "Tag", "Código", "Fecha de alta" };
            this.SearchArgumentFilters = new List<string>() { "Menor igual", "Mayor igual", "Igual", "Distinto", "Todos" };
        }

        public Command FindCommand
        {
            get
            {

                return new Command(() =>
                {
                    Application.Current.MainPage.DisplayAlert("Editar", this.SelectedItem + " - " + this.SelectedFilter, "Yes");
                    Navigation.PushAsync(new ResultadoBusquedaPage());
                });
            }
        }






    }
}