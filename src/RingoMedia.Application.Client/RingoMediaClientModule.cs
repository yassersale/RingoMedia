using Abp.Modules;
using Abp.Reflection.Extensions;

namespace RingoMedia
{
    public class RingoMediaClientModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(RingoMediaClientModule).GetAssembly());
        }
    }
}
