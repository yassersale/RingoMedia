using System.Threading.Tasks;
using Abp.Application.Services;
using RingoMedia.Sessions.Dto;

namespace RingoMedia.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();

        Task<UpdateUserSignInTokenOutput> UpdateUserSignInToken();
    }
}
