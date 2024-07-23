using System.Threading.Tasks;
using Abp.Application.Services;
using RingoMedia.Configuration.Tenants.Dto;

namespace RingoMedia.Configuration.Tenants
{
    public interface ITenantSettingsAppService : IApplicationService
    {
        Task<TenantSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(TenantSettingsEditDto input);

        Task ClearLogo();

        Task ClearCustomCss();
    }
}
