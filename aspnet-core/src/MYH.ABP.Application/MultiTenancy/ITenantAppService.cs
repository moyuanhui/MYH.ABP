using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MYH.ABP.MultiTenancy.Dto;

namespace MYH.ABP.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
