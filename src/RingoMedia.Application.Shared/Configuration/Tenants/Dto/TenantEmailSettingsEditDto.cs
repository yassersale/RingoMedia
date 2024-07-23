using Abp.Auditing;
using RingoMedia.Configuration.Dto;

namespace RingoMedia.Configuration.Tenants.Dto
{
    public class TenantEmailSettingsEditDto : EmailSettingsEditDto
    {
        public bool UseHostDefaultEmailSettings { get; set; }
    }
}