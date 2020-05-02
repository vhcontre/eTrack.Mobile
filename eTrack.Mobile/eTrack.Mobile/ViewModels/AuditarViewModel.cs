using eTrack.Mobile.Views;
using System.Windows.Input;
using Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTrack.Mobile.ViewModels
{
    public class AuditarViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }
        public ICommand CommandAcept { get; protected set; }
        public ICommand CommandCancel { get; protected set; }
        public ICommand CommandLocate { get; protected set; }
        public AuditarViewModel() { }

        public AuditarViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            this.CommandCancel = new Command(async () => await Application.Current.MainPage.DisplayAlert("Command Cancelar", "Se hizo clic en Cancelar", "Botón 2", "Botón 1"));
            this.CommandAcept = new Command(async () => await NewMethod());
            this.CommandLocate = new Command(async () => await Application.Current.MainPage.DisplayAlert("Command Ubicar", "Se hizo clic en Locate", "Yes"));

        }

        private static async Task NewMethod()
        {
            await Application.Current.MainPage.DisplayAlert("Command Aceptar", "Se hizo clic en Aceptar", "Yes", "No");
        }
    }
}