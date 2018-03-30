using System.Threading.Tasks;
using MYH.ABP.Configuration.Dto;

namespace MYH.ABP.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
