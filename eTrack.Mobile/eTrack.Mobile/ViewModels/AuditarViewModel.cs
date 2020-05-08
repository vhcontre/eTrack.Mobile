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
        public ICommand AcceptCommand { get; protected set; }
        public ICommand CancelCommand { get; protected set; }
        public ICommand LocateCommand { get; protected set; }
        public AuditarViewModel() { }

        public AuditarViewModel(INavigation navigation)
        {
            Title = "Registro de auditoria";
            this.Navigation = navigation;
            this.CancelCommand = new Command(async () => await Application.Current.MainPage.DisplayAlert("Command Cancelar", "Se hizo clic en Cancelar", "Botón 2", "Botón 1"));
            this.AcceptCommand = new Command(async () => await SaveCommand());
            this.LocateCommand = new Command(async () => await Application.Current.MainPage.DisplayAlert("Command Ubicar", "Se hizo clic en Locate", "Yes"));

        }

        private static async Task SaveCommand()
        {
            await Application.Current.MainPage.DisplayAlert("Command Aceptar", "Se hizo clic en Aceptar", "Yes", "No");
        }
    }
}