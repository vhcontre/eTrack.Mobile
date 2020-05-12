using eTrack.Mobile.Views;
using System.Windows.Input;
using Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eTrack.Mobile.Models;
using eTrack.Mobile.Services;
using eTrack.Mobile.Services.Exceptions;
using Rg.Plugins.Popup.Services;
using Acr.UserDialogs;
using System.Runtime.CompilerServices;

namespace eTrack.Mobile.ViewModels
{
   
    public class LoginViewModel : BaseViewModel
    {
        private string _userName;
        private string _userPassword;

        public string UserName
        {
            get { return _userName; }
            set { SetProperty(ref _userName, value); }
        }
        public string UserPassword
        {
            get { return _userPassword; }
            set { SetProperty(ref _userPassword, value); }
        }

        public User _user { get; set; }
        public INavigation Navigation { get; set; }
        public ICommand LoginCommand { get; internal set; }

        public User UserModel
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
                OnPropertyChanged();
            }
        }               

        public LoginViewModel() { }
        public LoginViewModel(INavigation navigation)
        {

            Title = "Iniciar sesión";
            this.Navigation = navigation;
            IsBusy = false;
            CleanupUserControls();
            LoginCommand = new Command(execute: OnLoginCommand);
            
        }

        public Command CloseCommand
        {
            get
            {
                return new Command(() =>
                {
                    Navigation.PushAsync(new SeleccionModoPage());
                });
            }
        }

        private void GetMessage()
        {
            
            if(UserModel.LoginName =="admin")
            {
                //Message = "UserName " + UsuarioModel.UserName + ", Passwords " + UsuarioModel.Password;
                this.Message = string.Empty;
                Navigation.PushAsync(new MenuPage());
            }
            else if (UserModel.LoginName == "catch")
            {
                Navigation.PushAsync(new ConfigPage());
            }
            else {
                Message = "Error en el inicio de Sesión. Credenciales incorrectas";
            }
        }


        public void CleanupUserControls()
        {
            UserName = string.Empty;
            UserPassword = string.Empty;
        }

        private async void OnLoginCommand()
        {
            try
            {
                IsBusy = true;

                // Se intenta realizar la validación de las credenciales de usuario.
                // Si las credenciales son válidas, se pasa a la página siguiente; en caso contrario,
                // se muestra un mensaje al usuario y no se pasa de página.
                UserInfoModel userInfo = await UserLoginService.Instance.LogIn(UserName, UserPassword);

                if (userInfo.IsFirstLogin)
                {
                    await PopupNavigation.Instance.PushAsync(new ChangePasswordPopup());
                    return;
                }

                CleanupUserControls();

                await Navigation.PushAsync(new MenuPage());
            }
            catch (AccessDeniedException ex)
            {
                CleanupUserControls();
                await UserDialogs.Instance.AlertAsync(ex.Message, "Login", "Ok");
            }
            catch (RepositoryException ex) //RepositoryException
            {
                CleanupUserControls();
                await UserDialogs.Instance.AlertAsync(UserMessageResources.DbConnectionError, "Error!", "Ok");
            }
            catch (DataOperationException ex)
            {
                CleanupUserControls();
                await UserDialogs.Instance.AlertAsync(ex.Message, "Error!", "Ok");
            }
            catch (Exception ex)
            {
                CleanupUserControls();
                await UserDialogs.Instance.AlertAsync(ex.Message, "Error!", "Ok");
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}