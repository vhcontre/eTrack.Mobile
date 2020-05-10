using eTrack.Mobile.Models.Enums;
using eTrack.Mobile.Services;
using System.Collections.Generic;

namespace eTrack.Mobile.Models
{
    public class User : IEntity
    {
        public string LoginName { get; set; }
        public string LoginPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsFirstLogin { get; set; }
        public bool CanBeDeleted { get; set; }
        public bool IsDefaultSysAdmin { get; set; }
        public bool Enabled { get; set; }
        public string Id { get; set; }
    }
    public class UserInfoModel : User
    {
        public IList<UserActionModel> Permissions { get; set; }
    }
    public class UserActionModel
    {
        public SystemActions Action { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}