using eTrack.Mobile.Views;
using Xamarin.Forms;

namespace eTrack.Mobile.ViewModels
{

    public class InventarioViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }
        public InventarioViewModel(INavigation navigation)
        {
            Title = "Inventario - Ejecución";
            this.Navigation = navigation;
        }
        public InventarioViewModel() { }
        public Command NoteCommand
        {
            get
            {
                return new Command(() => { Navigation.PushAsync(new InventarioNotasPage()); });
            }
        }
        public Command StartCommand
        {
            get
            {
                return new Command(() =>
                {
                    StartProcess();
                });
            }

        }
        private void StartProcess()
        {
            // Acceder a base de datos y guardar la información
            Application.Current.MainPage.DisplayAlert("Comenzar", "Iniciar proceso", "Yes");
        }
    }
}