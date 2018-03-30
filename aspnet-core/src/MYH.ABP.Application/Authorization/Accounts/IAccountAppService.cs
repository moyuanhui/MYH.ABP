using System.Threading.Tasks;
using Abp.Application.Services;
using MYH.ABP.Authorization.Accounts.Dto;

namespace MYH.ABP.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
