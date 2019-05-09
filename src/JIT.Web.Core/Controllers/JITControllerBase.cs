using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace JIT.Controllers
{
    public abstract class JITControllerBase: AbpController
    {
        protected JITControllerBase()
        {
            LocalizationSourceName = JITConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
