using System;
using System.Windows.Input;
using eTrack.Mobile.Models;
using eTrack.Mobile.Views;
using Xamarin.Forms;

namespace eTrack.Mobile.ViewModels.Asset
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
            Title = "Info";
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
}