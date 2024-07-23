using Abp.Application.Services;
using Abp.Application.Services.Dto;
using RingoMedia.Authorization.Permissions.Dto;

namespace RingoMedia.Authorization.Permissions
{
    public interface IPermissionAppService : IApplicationService
    {
        ListResultDto<FlatPermissionWithLevelDto> GetAllPermissions();
    }
}
