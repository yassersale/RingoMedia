using System.Collections.Generic;
using RingoMedia.Authorization.Permissions.Dto;

namespace RingoMedia.Web.Areas.AppAreaName.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }

        List<string> GrantedPermissionNames { get; set; }
    }
}