using System.Collections.Generic;
using RingoMedia.Authorization.Permissions.Dto;

namespace RingoMedia.Authorization.Users.Dto
{
    public class GetUserPermissionsForEditOutput
    {
        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}