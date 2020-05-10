using System.Threading.Tasks;
using eTrack.Mobile.Models;
using eTrack.Mobile.Models.Enums;

namespace eTrack.Mobile.Services
{
    public interface ILoginService
    {
        UserInfoModel CurrentUser { get; }
        Task<UserInfoModel> LogIn(string userName, string userPassword);
        void LogOut();
        bool CheckPermission(SystemActions permission);
        Task ChangePassword(string currentPassword, string newPassword);
        Task TestConnection();
    }
}