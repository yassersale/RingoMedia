using Abp.AspNetCore.Mvc.ViewComponents;

namespace RingoMedia.Web.Views
{
    public abstract class RingoMediaViewComponent : AbpViewComponent
    {
        protected RingoMediaViewComponent()
        {
            LocalizationSourceName = RingoMediaConsts.LocalizationSourceName;
        }
    }
}