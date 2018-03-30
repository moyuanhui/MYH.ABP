using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;

namespace MYH.ABP.Web.Views
{
    public abstract class ABPRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected ABPRazorPage()
        {
            LocalizationSourceName = ABPConsts.LocalizationSourceName;
        }
    }
}
