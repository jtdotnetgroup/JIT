using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using JIT.Authorization;
using JITEF;

namespace JIT
{
    [DependsOn(
        typeof(JITCoreModule), 
        typeof(AbpAutoMapperModule)
        )]
    public class JITApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<JITAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(JITApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
