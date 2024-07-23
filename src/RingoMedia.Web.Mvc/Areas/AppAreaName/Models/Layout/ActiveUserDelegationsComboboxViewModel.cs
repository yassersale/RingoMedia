using System.Collections.Generic;
using RingoMedia.Authorization.Delegation;
using RingoMedia.Authorization.Users.Delegation.Dto;

namespace RingoMedia.Web.Areas.AppAreaName.Models.Layout
{
    public class ActiveUserDelegationsComboboxViewModel
    {
        public IUserDelegationConfiguration UserDelegationConfiguration { get; set; }

        public List<UserDelegationDto> UserDelegations { get; set; }

        public string CssClass { get; set; }
    }
}
