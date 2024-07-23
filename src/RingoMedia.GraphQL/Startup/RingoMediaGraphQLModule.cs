using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace RingoMedia.Startup
{
    [DependsOn(typeof(RingoMediaCoreModule))]
    public class RingoMediaGraphQLModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(RingoMediaGraphQLModule).GetAssembly());
        }

        public override void PreInitialize()
        {
            base.PreInitialize();

            //Adding custom AutoMapper configuration
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);
        }
    }
}