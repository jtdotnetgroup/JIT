using System.Threading.Tasks;
using JIT.Configuration.Dto;

namespace JIT.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
