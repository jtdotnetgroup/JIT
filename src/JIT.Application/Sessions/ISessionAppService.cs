using System.Threading.Tasks;
using Abp.Application.Services;
using JIT.Sessions.Dto;

namespace JIT.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
