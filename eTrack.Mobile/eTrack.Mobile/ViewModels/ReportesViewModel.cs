using eTrack.Mobile.Models;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;
using eTrack.Mobile.Views;

namespace eTrack.Mobile.ViewModels
{
    //ResultadoReportePage
    public class ResultadoReporteViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }
        public ICommand AcceptCommand { get; protected set; }
        public ICommand CancelCommand { get; protected set; }

        
        public ResultadoReporteViewModel() { }

        public ResultadoReporteViewModel(INavigation navigation)
        {
            Title = "Auditorías registradas";
            this.Navigation = navigation;
            //this.CancelCommand = new Command(async () => await Application.Current.MainPage.DisplayAlert("Command Cancelar", "Se hizo clic en Cancelar", "Ok"));
            //this.AcceptCommand = new Command(async () => await ResultadoReporte());

        }
        private async Task ResultadoReporte()
        {
            //await Application.Current.MainPage.DisplayAlert("Command Aceptar", "Se hizo clic en Aceptar", "Yes", "No");
            //await this.Navigation.PushAsync(new ResultadoReportePage());
            //await this.Navigation.PushAsync(new ResultadoHistorialPage());
        }
    }
    public class ReportesViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }
        public ICommand AcceptCommand { get; protected set; }
        public ICommand CancelCommand { get; protected set; }
        public ReportesViewModel() { }

        public ReportesViewModel(INavigation navigation)
        {
            Title = "Reportes de auditorías";
            this.Navigation = navigation;
            this.CancelCommand = new Command(async () => await Application.Current.MainPage.DisplayAlert("Command Cancelar", "Se hizo clic en Cancelar", "Ok"));
            this.AcceptCommand = new Command(async () => await ResultadoReporte());

        }
        private async Task ResultadoReporte()
        {
            //await Application.Current.MainPage.DisplayAlert("Command Aceptar", "Se hizo clic en Aceptar", "Yes", "No");
            await this.Navigation.PushAsync(new ResultadoReportePage());
            //await this.Navigation.PushAsync(new ResultadoHistorialPage());
        }
    }
}