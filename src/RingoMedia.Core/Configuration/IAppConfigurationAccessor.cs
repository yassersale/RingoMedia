using Microsoft.Extensions.Configuration;

namespace RingoMedia.Configuration
{
    public interface IAppConfigurationAccessor
    {
        IConfigurationRoot Configuration { get; }
    }
}
