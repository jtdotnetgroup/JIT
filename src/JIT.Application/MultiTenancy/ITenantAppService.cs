using Abp.Application.Services;
using Abp.Application.Services.Dto;
using JIT.MultiTenancy.Dto;

namespace JIT.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

