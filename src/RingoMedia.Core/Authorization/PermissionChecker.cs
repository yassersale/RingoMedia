using Abp.Authorization;
using RingoMedia.Authorization.Roles;
using RingoMedia.Authorization.Users;

namespace RingoMedia.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
