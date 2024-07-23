using System.Collections.Generic;
using RingoMedia.Caching.Dto;

namespace RingoMedia.Web.Areas.AppAreaName.Models.Maintenance
{
    public class MaintenanceViewModel
    {
        public IReadOnlyList<CacheDto> Caches { get; set; }
    }
}