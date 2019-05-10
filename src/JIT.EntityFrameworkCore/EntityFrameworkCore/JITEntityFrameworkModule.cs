using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using JIT.EntityFrameworkCore.Seed;

namespace JIT.EntityFrameworkCore
{
    [DependsOn(
        typeof(JITCoreModule), 
        typeof(AbpZeroCoreEntityFrameworkCoreModule))]
    public class JITEntityFrameworkModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<JITDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        JITDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        JITDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });

            }
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(JITEntityFrameworkModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            if (!SkipDbSeed)
            {
                SeedHelper.SeedHostDb(IocManager);
            }
        }
    }
}
