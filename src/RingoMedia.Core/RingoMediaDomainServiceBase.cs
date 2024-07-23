using Abp.Domain.Services;

namespace RingoMedia
{
    public abstract class RingoMediaDomainServiceBase : DomainService
    {

        /* Add your common members for all your domain services. */

        protected RingoMediaDomainServiceBase()
        {
            LocalizationSourceName = RingoMediaConsts.LocalizationSourceName;
        }
    }
}
