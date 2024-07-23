using Abp.AutoMapper;
using RingoMedia.Authorization.Users;
using RingoMedia.Authorization.Users.Dto;
using RingoMedia.Web.Areas.AppAreaName.Models.Common;

namespace RingoMedia.Web.Areas.AppAreaName.Models.Users
{
    [AutoMapFrom(typeof(GetUserPermissionsForEditOutput))]
    public class UserPermissionsEditViewModel : GetUserPermissionsForEditOutput, IPermissionsEditViewModel
    {
        public User User { get; set; }
    }
}