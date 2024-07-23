using Abp.Zero.Ldap.Authentication;
using Abp.Zero.Ldap.Configuration;
using RingoMedia.Authorization.Users;
using RingoMedia.MultiTenancy;

namespace RingoMedia.Authorization.Ldap
{
    public class AppLdapAuthenticationSource : LdapAuthenticationSource<Tenant, User>
    {
        public AppLdapAuthenticationSource(ILdapSettings settings, IAbpZeroLdapModuleConfig ldapModuleConfig)
            : base(settings, ldapModuleConfig)
        {
        }
    }
}