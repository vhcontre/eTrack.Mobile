using System.Collections.Generic;
using eTrack.Mobile.Views;
using Xamarin.Forms;

namespace eTrack.Mobile.ViewModels.Asset
{
    public class AssetFindViewModel : BaseViewModel
    {
        public AssetFindViewModel() { }
        #region Aplicar filtros Activos
        public IList<string> SearchAssetFilters { get; set; }
        string _argAssetFilter;
        public string SelectedAssetFilter
        {
            get { return _argAssetFilter; }
            set
            {
                if (_argAssetFilter != value)
                {
                    if (string.IsNullOrWhiteSpace(value))
                        _argAssetFilter = "Todos";
                    _argAssetFilter = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion
        public INavigation Navigation { get; set; }

        public AssetFindViewModel(INavigation navigation)
        {
            Title = "Búsqueda de activo";
            this.Navigation = navigation;
            this.SearchArgumentList = new List<string>() { "Tag", "Código", "Fecha de alta" };
            this.SearchArgumentFilters = new List<string>() { "Menor igual", "Mayor igual", "Igual", "Distinto", "Todos" };
            this.SearchAssetFilters = new List<string>() { "Activos con acciones ", "Activos sin acciones ", "Todos" };
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