using System.Threading.Tasks;

namespace RingoMedia.Net.Sms
{
    public interface ISmsSender
    {
        Task SendAsync(string number, string message);
    }
}