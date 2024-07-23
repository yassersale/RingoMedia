using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RingoMedia.Web.Areas.AppAreaName.Models.Layout;
using RingoMedia.Web.Session;
using RingoMedia.Web.Views;

namespace RingoMedia.Web.Areas.AppAreaName.Views.Shared.Themes.Theme5.Components.AppAreaNameTheme5Brand
{
    public class AppAreaNameTheme5BrandViewComponent : RingoMediaViewComponent
    {
        private readonly IPerRequestSessionCache _sessionCache;

        public AppAreaNameTheme5BrandViewComponent(IPerRequestSessionCache sessionCache)
        {
            _sessionCache = sessionCache;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var headerModel = new HeaderViewModel
            {
                LoginInformations = await _sessionCache.GetCurrentLoginInformationsAsync()
            };

            return View(headerModel);
        }
    }
}
