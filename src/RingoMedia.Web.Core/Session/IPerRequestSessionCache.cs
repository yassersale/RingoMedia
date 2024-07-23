using System.Threading.Tasks;
using RingoMedia.Sessions.Dto;

namespace RingoMedia.Web.Session
{
    public interface IPerRequestSessionCache
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformationsAsync();
    }
}
