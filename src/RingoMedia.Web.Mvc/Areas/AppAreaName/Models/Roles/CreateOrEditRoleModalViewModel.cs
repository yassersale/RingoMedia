using Abp.AutoMapper;
using RingoMedia.Authorization.Roles.Dto;
using RingoMedia.Web.Areas.AppAreaName.Models.Common;

namespace RingoMedia.Web.Areas.AppAreaName.Models.Roles
{
    [AutoMapFrom(typeof(GetRoleForEditOutput))]
    public class CreateOrEditRoleModalViewModel : GetRoleForEditOutput, IPermissionsEditViewModel
    {
        public bool IsEditMode => Role.Id.HasValue;
    }
}