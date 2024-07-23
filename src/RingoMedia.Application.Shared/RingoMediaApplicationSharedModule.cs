using Abp.Modules;
using Abp.Reflection.Extensions;

namespace RingoMedia
{
    [DependsOn(typeof(RingoMediaCoreSharedModule))]
    public class RingoMediaApplicationSharedModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(RingoMediaApplicationSharedModule).GetAssembly());
        }
    }
}