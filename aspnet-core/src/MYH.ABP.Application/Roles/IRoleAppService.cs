using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MYH.ABP.Roles.Dto;

namespace MYH.ABP.Roles
{
    public interface IRoleAppService : IAsyncCrudAppService<RoleDto, int, PagedResultRequestDto, CreateRoleDto, RoleDto>
    {
        Task<ListResultDto<PermissionDto>> GetAllPermissions();
    }
}
