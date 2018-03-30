using Abp.AspNetCore.Mvc.ViewComponents;

namespace MYH.ABP.Web.Views
{
    public abstract class ABPViewComponent : AbpViewComponent
    {
        protected ABPViewComponent()
        {
            LocalizationSourceName = ABPConsts.LocalizationSourceName;
        }
    }
}
