using System.Threading.Tasks;
using RingoMedia.Authorization.Users;

namespace RingoMedia.WebHooks
{
    public interface IAppWebhookPublisher
    {
        Task PublishTestWebhook();
    }
}
