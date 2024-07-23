using Abp.Application.Services;
using Abp.Application.Services.Dto;
using RingoMedia.Common.Dto;
using System.Threading.Tasks;

namespace RingoMedia.Common
{
    public interface ICommonLookupAppService : IApplicationService
    {

        Task<PagedResultDto<NameValueDto>> FindUsers(FindUsersInput input);

        GetDefaultEditionNameOutput GetDefaultEditionName();
    }
}