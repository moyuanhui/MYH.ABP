using System.Threading.Tasks;
using Abp.Application.Services;
using MYH.ABP.Sessions.Dto;

namespace MYH.ABP.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
