using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MYH.ABP.Roles.Dto;
using MYH.ABP.Users.Dto;

namespace MYH.ABP.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
