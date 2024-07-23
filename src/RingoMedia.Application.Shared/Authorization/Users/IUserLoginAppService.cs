using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using RingoMedia.Authorization.Users.Dto;

namespace RingoMedia.Authorization.Users
{
    public interface IUserLoginAppService : IApplicationService
    {
        Task<PagedResultDto<UserLoginAttemptDto>> GetUserLoginAttempts(GetLoginAttemptsInput input);
    }
}
