using Abp.Application.Services.Dto;
using RingoMedia.Configuration.Host.Dto;
using System.Collections.Generic;

namespace RingoMedia.Web.Areas.AppAreaName.Models.HostSettings
{
    public class HostSettingsViewModel
    {
        public HostSettingsEditDto Settings { get; set; }


        public List<ComboboxItemDto> TimezoneItems { get; set; }

        public List<string> EnabledSocialLoginSettings { get; set; } = new List<string>();
    }
}