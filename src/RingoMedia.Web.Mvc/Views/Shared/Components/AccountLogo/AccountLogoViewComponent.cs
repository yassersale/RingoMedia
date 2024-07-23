using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RingoMedia.Web.Session;

namespace RingoMedia.Web.Views.Shared.Components.AccountLogo
{
    public class AccountLogoViewComponent : RingoMediaViewComponent
    {
        private readonly IPerRequestSessionCache _sessionCache;

        public AccountLogoViewComponent(IPerRequestSessionCache sessionCache)
        {
            _sessionCache = sessionCache;
        }

        public async Task<IViewComponentResult> InvokeAsync(string skin)
        {
            var loginInfo = await _sessionCache.GetCurrentLoginInformationsAsync();
            return View(new AccountLogoViewModel(loginInfo, skin));
        }
    }
}
