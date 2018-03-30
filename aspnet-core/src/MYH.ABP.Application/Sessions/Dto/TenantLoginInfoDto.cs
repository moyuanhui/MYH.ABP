using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MYH.ABP.MultiTenancy;

namespace MYH.ABP.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}
