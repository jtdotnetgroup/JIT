using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using JIT.Configuration;
using JITEF;

namespace JIT.Web.Host.Startup
{
    [DependsOn(
       typeof(JITWebCoreModule),typeof(JITEFModule))]
    public class JITWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public JITWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(JITWebHostModule).GetAssembly());
        }
    }
}
