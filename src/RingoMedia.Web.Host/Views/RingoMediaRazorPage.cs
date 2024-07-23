using Abp.AspNetCore.Mvc.Views;

namespace RingoMedia.Web.Views
{
    public abstract class RingoMediaRazorPage<TModel> : AbpRazorPage<TModel>
    {
        protected RingoMediaRazorPage()
        {
            LocalizationSourceName = RingoMediaConsts.LocalizationSourceName;
        }
    }
}
