using eTrack.Mobile.Views;
using Xamarin.Forms;

namespace eTrack.Mobile.ViewModels
{
    //InventarioNotasPage
    public class InventarioNotasViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }
        public InventarioNotasViewModel(INavigation navigation)
        {
            Title = "Inventario - Notas";
            this.Navigation = navigation;
        }
        public InventarioNotasViewModel() { }
        
        public Command SaveCommand
        {
            get
            {
                return new Command(() =>
                {
                    Save();
                });
            }

        }
        private void Save()
        {
            // Acceder a base de datos y guardar la información
            Application.Current.MainPage.DisplayAlert("Guardar", "Guardar notas", "Yes");
        }
    }
    public class PreparacionInventarioViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }
        public PreparacionInventarioViewModel(INavigation navigation)
        {
            Title = "Inventario - Preparación";
            this.Navigation = navigation;
        }
        public PreparacionInventarioViewModel() { }
        public Command InventoryCommand
        {
            get
            {
                return new Command(() => { Navigation.PushAsync(new InventarioPage()); });
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