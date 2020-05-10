using System;

using Xamarin.Forms;
using eTrack.Mobile.Services;
using eTrack.Mobile.Services.Exceptions;
using System.Windows.Input;
using Rg.Plugins.Popup.Services;

namespace eTrack.Mobile.ViewModels
{
    public class ChangePasswordViewModel : BaseViewModel
    {
        private string _currentPassword;
        private string _newPassword1;
        private string _newPassword2;

        public string CurrentPassword
        {
            get { return _currentPassword; }
            set { SetProperty(ref _currentPassword, value); }
        }

        public string NewPassword1
        {
            get { return _newPassword1; }
            set { SetProperty(ref _newPassword1, value); }
        }

        public string NewPassword2
        {
            get { return _newPassword2; }
            set { SetProperty(ref _newPassword2, value); }
        }

        public ICommand AcceptCommand { get; internal set; }
        public ICommand CancelCommand { get; internal set; }

        public ChangePasswordViewModel()
        {
            CleanupUserControls();

            AcceptCommand = new Command(execute: OnAcceptCommand);
            CancelCommand = new Command(execute: OnCancelCommand);
        }

        private void OnCancelCommand(object obj)
        {
            throw new NotImplementedException();
        }

        private async void OnAcceptCommand(object obj)
        {
            
            await UserLoginService.Instance.ChangePassword(CurrentPassword, NewPassword1);
            await PopupNavigation.Instance.PopAsync(true);
        }

        //private async void OnAcceptCommand()
        //{
        //    if (string.IsNullOrEmpty(NewPassword1.Trim()) || (NewPassword1 != NewPassword2))
        //    {
        //        await UserDialogs.Instance.AlertAsync("La nueva contraseña está vacía o las contraseñas no coinciden!\r\nIngrese la nueva contraseña, y repítala a continuación.", "Cambio de Contraseña", "Aceptar");
        //    }

        //    try
        //    {
        //        await UserLoginService.Instance.ChangePassword(CurrentPassword, NewPassword1);
        //    }
        //    catch (UserCredentialsException ex)
        //    {
        //        await UserDialogs.Instance.AlertAsync(ex.Message, "Error", "Aceptar");
        //    }
        //    catch (Exception ex)
        //    {
        //        await UserDialogs.Instance.AlertAsync(ex.Message, "Error", "Aceptar");
        //    }
        //    finally
        //    {
        //        await PopupNavigation.Instance.PopAsync(true);
        //    }
        //}

        //private async void OnCancelCommand()
        //{
        //    await PopupNavigation.Instance.PopAsync(true);
        //}

        public void CleanupUserControls()
        {
            CurrentPassword = string.Empty;
            NewPassword1 = string.Empty;
            NewPassword2 = string.Empty;
        }
    }
}
