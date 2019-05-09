using System.Data.Entity;
using Abp.Modules;
using Abp.Reflection.Extensions;
using JIT;
using JITEF.DIME2Barcode;

namespace JITEF
{
    [DependsOn(typeof(JITCoreModule))]
    public class JITEFModule:AbpModule
    {
        public override void PreInitialize()
        {
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(JITEFModule).GetAssembly());
        }
    }
}