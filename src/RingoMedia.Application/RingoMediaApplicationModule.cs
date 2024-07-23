using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using RingoMedia.Authorization;

namespace RingoMedia
{
    /// <summary>
    /// Application layer module of the application.
    /// </summary>
    [DependsOn(
        typeof(RingoMediaApplicationSharedModule),
        typeof(RingoMediaCoreModule)
        )]
    public class RingoMediaApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Adding authorization providers
            Configuration.Authorization.Providers.Add<AppAuthorizationProvider>();

            //Adding custom AutoMapper configuration
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(RingoMediaApplicationModule).GetAssembly());
        }
    }
}