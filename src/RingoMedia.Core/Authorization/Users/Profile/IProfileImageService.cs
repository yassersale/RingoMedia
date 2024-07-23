using Abp;
using Abp.Domain.Services;
using System.Threading.Tasks;

namespace RingoMedia.Authorization.Users.Profile
{
    public interface IProfileImageService : IDomainService
    {
        Task<string> GetProfilePictureContentForUser(UserIdentifier userIdentifier);
    }
}