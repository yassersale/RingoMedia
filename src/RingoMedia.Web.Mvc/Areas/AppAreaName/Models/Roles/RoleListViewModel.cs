using System.Collections.Generic;
using Abp.Application.Services.Dto;
using RingoMedia.Authorization.Permissions.Dto;
using RingoMedia.Web.Areas.AppAreaName.Models.Common;

namespace RingoMedia.Web.Areas.AppAreaName.Models.Roles
{
    public class RoleListViewModel : IPermissionsEditViewModel
    {
        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}