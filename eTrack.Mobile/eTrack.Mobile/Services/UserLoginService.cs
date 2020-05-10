using System.Threading.Tasks;
using eTrack.Mobile.Models;
using eTrack.Mobile.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Xamarin.Forms;

namespace eTrack.Mobile.Services
{
    public sealed class UserLoginService : ILoginService
    {

        private static bool userIsFirstLogin = true;
        private static readonly Lazy<UserLoginService> lazy = new Lazy<UserLoginService>(() => new UserLoginService());

        /// <summary>
        /// Devuelve la instancia del Singleton
        /// </summary>
        public static ILoginService Instance
        {
            get { return lazy.Value; }
        }

        /// <summary>
        /// Devuelve
        /// </summary>
        public UserInfoModel CurrentUser
        {
            get;
            internal set;
        }

        /// <summary>
        /// Constructor privado para evitar la instanciación de la clase por fuera del Singleton
        /// </summary>
        private UserLoginService()
        {
        }

        public async Task ChangePassword(string currentPassword, string newPassword)
        {
            await Task.Run(() =>
            {
                userIsFirstLogin = false;
            });
            
        }

        public bool CheckPermission(SystemActions permission)
        {
            return true;
        }

        public async Task<UserInfoModel> LogIn(string userName, string userPassword)
        {
            return await Task.Run(() =>
            {
                var userInfo = GetUserInfo(userName, userPassword);

                if (!userInfo.Enabled)
                {
                    //AccessDeniedException
                    throw new Exception (UserMessageResources.UserIsDisabled);
                }

                if (!CheckPermission(SystemActions.AccessMobileTerminal))
                {
                    //AccessDeniedException
                    throw new Exception(UserMessageResources.LoginNotAllowed);
                }

                return userInfo;
            });
        }

        public void LogOut()
        {
            throw new System.NotImplementedException();
        }

        public Task TestConnection()
        {
            throw new System.NotImplementedException();
        }

        private UserInfoModel GetUserInfo(string userName, string userPassword)
        {
            if (IsDefaultConfigUser(userName, userPassword))
            {
                return CurrentUser = GetDefaultConfigUserInfo(userPassword);
            }

            var user = GetUser(userName, userPassword);
            var permissions = GetUserPermissions(user.Id);

            return CurrentUser = new UserInfoModel()
            {
                CanBeDeleted = user.CanBeDeleted,
                Enabled = user.Enabled,
                FirstName = user.FirstName,
                Id = user.Id,
                IsDefaultSysAdmin = user.IsDefaultSysAdmin,
                IsFirstLogin = user.IsFirstLogin,
                LastName = user.LastName,
                LoginName = user.LoginName,
                LoginPassword = user.LoginPassword,
                Permissions = permissions
            };
        }

        private IList<UserActionModel> GetUserPermissions(string id)
        {
            return new List<UserActionModel>();
        }

        private User GetUser(string userName, string userPassword)
        {
            if (string.IsNullOrEmpty(userName.Trim()))
            {
                var service = DependencyService.Get<IAndroidMethods>();
                var deviceId = service.GetDeviceId();

                //throw new UserCredentialsException(string.Format(UserMessageResources.EmptyUserCredentials, deviceId));
                throw new Exception();
            }
            var user = new User
            {
                Enabled = true,
                FirstName = "Default",
                LastName = "Config",
                IsDefaultSysAdmin = false,
                LoginName = "admin",
                LoginPassword = "loginPassword",
                IsFirstLogin = userIsFirstLogin,
            };
            return user;
        }

        private bool IsDefaultConfigUser(string userName, string userPassword)
        {
            if (!string.IsNullOrEmpty(userName.Trim()))
            {
                return false;
            }

            var service = DependencyService.Get<IAndroidMethods>();
            var deviceId = service.GetDeviceId();

            return userPassword == deviceId;
        }

        private UserInfoModel GetDefaultConfigUserInfo(string userPassword)
        {
            return new UserInfoModel()
            {
                Enabled = true,
                FirstName = "Default",
                LastName = "Config",
                IsDefaultSysAdmin = false, 
                LoginName = "config",
                LoginPassword = userPassword,
                Permissions = new List<UserActionModel>()
                    {
                        new UserActionModel()
                        {
                            Action = SystemActions.ModifyConfiguration,
                            Name = SystemActions.ModifyConfiguration.ToString(),
                            Description = "Default configuration permission"
                        },
                        new UserActionModel()
                        {
                            Action = SystemActions.AccessMobileTerminal,
                            Name = SystemActions.AccessMobileTerminal.ToString(),
                            Description = "Default mobile terminal access"
                        }
                    }
            };
        }



        private string GetEncryptedPassword(string password)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] hashResult;

            using (var sha1Crypter = SHA1.Create())
            {
                hashResult = sha1Crypter.ComputeHash(passwordBytes);
            }

            return Convert.ToBase64String(hashResult);
        }
    }
}