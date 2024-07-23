using System.Collections.Generic;
using System.Threading.Tasks;
using Abp;
using RingoMedia.Dto;

namespace RingoMedia.Gdpr
{
    public interface IUserCollectedDataProvider
    {
        Task<List<FileDto>> GetFiles(UserIdentifier user);
    }
}
