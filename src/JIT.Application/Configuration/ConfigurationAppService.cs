using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using JIT.Configuration.Dto;

namespace JIT.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : JITAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
