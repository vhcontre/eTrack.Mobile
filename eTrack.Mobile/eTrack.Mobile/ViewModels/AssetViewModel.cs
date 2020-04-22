using System.Windows.Input;
using eTrack.Mobile.Models;

namespace eTrack.Mobile.ViewModels
{
    public class AssetViewModel : BaseViewModel
    {
        public Asset Asset { get; set; }
        public AssetViewModel()
        {
            Title = "Datos del activo";

        }
        public ICommand OpenWebCommand { get; }
    }
}