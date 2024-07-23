using System.Threading.Tasks;
using Abp.Application.Services;
using RingoMedia.Install.Dto;

namespace RingoMedia.Install
{
    public interface IInstallAppService : IApplicationService
    {
        Task Setup(InstallDto input);

        AppSettingsJsonDto GetAppSettingsJson();

        CheckDatabaseOutput CheckDatabase();
    }
}