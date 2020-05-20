using System;
using System.Collections.Generic;
using System.Reflection;
using Acr.UserDialogs;
using eTrack.Mobile.Views;
using Xamarin.Forms;

namespace eTrack.Mobile.ViewModels.Asset
{
    public class AssetFindViewModel : BaseViewModel
    {
        public string SearchArgument { get; set; }
        public DateTime SelectedDate { get; set; }
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

                    var data = string.Format("{0}{1}{2}{3}",
                        this.SelectedItem,
                        (SelectedItem == "Fecha de alta") ? SelectedDate.ToString("dd/MM/yyyy") : SearchArgument,
                        this.SelectedFilter, this.SelectedAssetFilter);
                    UserDialogs.Instance.Alert(data, "Valores");

                    
                    Navigation.PushAsync(new ResultadoBusquedaPage());
                });
            }
        }






    }
}