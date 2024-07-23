using Abp.Application.Services;
using RingoMedia.Dto;
using RingoMedia.Logging.Dto;

namespace RingoMedia.Logging
{
    public interface IWebLogAppService : IApplicationService
    {
        GetLatestWebLogsOutput GetLatestWebLogs();

        FileDto DownloadWebLogs();
    }
}
