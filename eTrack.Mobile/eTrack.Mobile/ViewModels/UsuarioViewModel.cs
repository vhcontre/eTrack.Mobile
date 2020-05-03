using eTrack.Mobile.Views;
using System.Windows.Input;
using Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eTrack.Mobile.Models;

namespace eTrack.Mobile.ViewModels
{
   
    public class UsuarioViewModel : BaseViewModel
    {
        public Usuario _usuario { get; set; }
        public INavigation Navigation { get; set; }
        public Usuario UsuarioModel
        {
            get
            {
                return _usuario;
            }
            set
            {
                _usuario = value;
                OnPropertyChanged();
            }
        }

        private string _message;

        public UsuarioViewModel() { }
        public UsuarioViewModel(INavigation navigation)
        {
            Title = "Iniciar sesión";
            this.Navigation = navigation;
            UsuarioModel = new Usuario();
        }

        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }
        public Command LoginCommand
        {
            get
            {
                return new Command(() =>
                {
                    GetMessage();
                });
            }
        }

        public Command CloseCommand
        {
            get
            {
                return new Command(() =>
                {
                    Navigation.PushModalAsync(new NavigationPage(new SeleccionModoPage()));
                });
            }
        }

        private void GetMessage()
        {
            Message = "UserName " + UsuarioModel.UserName + ", Passwords " + UsuarioModel.Password;
            if(UsuarioModel.UserName =="admin")
            {
                //Navigation.PushAsync(new MenuPage());
                Navigation.PushModalAsync(new NavigationPage(new MenuPage()));
            }
            else if (UsuarioModel.UserName == "catch")
            {
                //Navigation.PushAsync(new ConfigPage());
                Navigation.PushModalAsync(new NavigationPage(new ConfigPage()));
            }
            else {
                Message = "Error en el inicio de Sesión.";
            }
        }

        
    }
}