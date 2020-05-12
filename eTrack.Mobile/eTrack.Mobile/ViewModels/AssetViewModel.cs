using System;
using System.Collections.Generic;
using System.Windows.Input;
using eTrack.Mobile.Models;
using eTrack.Mobile.Views;
using Xamarin.Forms;

namespace eTrack.Mobile.ViewModels
{
    public class AssetViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }
        public ICommand AddCommand { get; protected set; }
        public AssetViewModel(INavigation navigation)
        {
            Title = "Datos del activo";
            this.Navigation = navigation;
            this.AddCommand = new Command(async () => await Navigation.PushAsync(new AltaActivoPage()));
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
            this.AssetModel = new AssetModel();
            //this.BaseCommand = new Command(async () => await Navigation.PushAsync(new AltaActivoPage()));
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
            Application.Current.MainPage.DisplayAlert("Guardar", "Se guardo el Activo", "Yes");
        }
    }

    public class AssetEditViewModel : BaseViewModel
    {
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
            var _assetModel = new AssetModel
            {
                Code = DateTime.Now.Millisecond.ToString(),
                SapId = "980",
                Tag = Guid.NewGuid().ToString(),
                CostCenterName = "Moreno"
            };

            this.AssetModel = _assetModel;
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
            Application.Current.MainPage.DisplayAlert("Editar", "Se guardo el Activo", "Yes");
        }
    }

    public class AssetFindViewModel : BaseViewModel
    {
        public AssetFindViewModel()
        {
        }
        public INavigation Navigation { get; set; }

        private AssetModel _assetModel;

        public AssetModel AssetModel
        {
            get { return _assetModel; }
            set { _assetModel = value; OnPropertyChanged(); }
        }

        public AssetFindViewModel(INavigation navigation)
        {
            Title = "Búsqueda de activo";
            this.Navigation = navigation;
            var _assetModel = new AssetModel();
            this.AssetModel = _assetModel;
        }

        public Command FindCommand
        {
            get
            {
                
                return new Command(() => {
                    var data = this.SelectedName; 
                    Navigation.PushAsync(new ResultadoBusquedaPage()); });
            }
        }


        #region Buscar por Tag, Código o Fecha
        public IList<string> ListSearchArgument
        {
            get
            {
                return new List<string>() { "Tag", "Código", "Fecha de alta" };
            }
        }
        string selectedArgName;
        public string SelectedName
        {
            get { return selectedArgName; }
            set
            {
                if (selectedArgName != value)
                {
                    selectedArgName = value;
                    OnPropertyChanged();
                    //OnPropertyChanged("SelectedItem");
                }
            }
        }
        //private string SelectedItem
        //{
        //    get
        //    {
        //        if (string.IsNullOrWhiteSpace(selectedArgName))
        //        {
        //            return selectedArgName;
        //        }
        //        return "Tag";
        //    }
        //}
        #endregion



    }
}