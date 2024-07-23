using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using RingoMedia.Web.Controllers;

namespace RingoMedia.Web.Areas.AppAreaName.Controllers
{
    [Area("AppAreaName")]
    [AbpMvcAuthorize]
    public class WelcomeController : RingoMediaControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}