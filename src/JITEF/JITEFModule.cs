using System.Data.Entity;
using System.Reflection;
using Abp.Configuration.Startup;
using Abp.Domain.Uow;
using Abp.EntityFramework;
using Abp.Modules;
using Abp.Reflection.Extensions;
using JIT;
using JIT.EntityFrameworkCore;
using JITEF.DIME2Barcode;

namespace JITEF
{
    [DependsOn(typeof(JITCoreModule))]
    public class JITEFModule:AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.ReplaceService<IConnectionStringResolver, DIME2BarcondeResolver>();
            //Configuration.DefaultNameOrConnectionString = "DIME2Barcode";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(JITEFModule).GetAssembly());
            Database.SetInitializer(
                new CreateDatabaseIfNotExists<DIME2BarcodeContext>()
                );
        }
    }
}