using Abp.Modules;
using Abp.Reflection.Extensions;

namespace RingoMedia
{
    public class RingoMediaCoreSharedModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(RingoMediaCoreSharedModule).GetAssembly());
        }
    }
}