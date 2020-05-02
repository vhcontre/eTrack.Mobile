using eTrack.Mobile.Models;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;
using eTrack.Mobile.Views;

namespace eTrack.Mobile.ViewModels
{
    public class ReportesViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }
        public ICommand CommandAcept { get; protected set; }
        public ICommand CommandCancel { get; protected set; }
        public ICommand CommandLocate { get; protected set; }
        public ReportesViewModel() { }

        public ReportesViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            this.CommandCancel = new Command(async () => await Application.Current.MainPage.DisplayAlert("Command Cancelar", "Se hizo clic en Cancelar", "Botón 2", "Botón 1"));
            this.CommandAcept = new Command(async () => await ResultadoReporte());

        }
        private async Task ResultadoReporte()
        {
            //await Application.Current.MainPage.DisplayAlert("Command Aceptar", "Se hizo clic en Aceptar", "Yes", "No");
            //await this.Navigation.PushAsync(new ResultadoReportePage());
            //await this.Navigation.PushAsync(new ResultadoHistorialPage());
            await this.Navigation.PushAsync(new SearchAssetToAssociatePage());
        }
    }
}