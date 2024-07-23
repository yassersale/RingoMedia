using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RingoMedia.Web.Areas.AppAreaName.Models.Layout;
using RingoMedia.Web.Views;

namespace RingoMedia.Web.Areas.AppAreaName.Views.Shared.Components.AppAreaNameRecentNotifications
{
    public class AppAreaNameRecentNotificationsViewComponent : RingoMediaViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(string cssClass, string iconClass = "flaticon-alert-2 unread-notification fs-2")
        {
            var model = new RecentNotificationsViewModel
            {
                CssClass = cssClass,
                IconClass = iconClass
            };
            
            return Task.FromResult<IViewComponentResult>(View(model));
        }
    }
}
