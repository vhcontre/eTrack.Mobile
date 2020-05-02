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

        private void GetMessage()
        {
            Message = "UserName " + UsuarioModel.UserName + ", Passwords " + UsuarioModel.Password;
            if(UsuarioModel.UserName =="vcontreras")
            {
                Navigation.PushAsync(new ResultadoReportePage());
            }
        }

        
    }
}