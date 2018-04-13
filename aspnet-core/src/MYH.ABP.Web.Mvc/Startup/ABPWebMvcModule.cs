using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MYH.ABP.Configuration;
using Abp.Runtime.Caching.Redis;


namespace MYH.ABP.Web.Startup
{
    [DependsOn(
        typeof(ABPWebCoreModule))]
    public class ABPWebMvcModule : AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public ABPWebMvcModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
          


            Configuration.Navigation.Providers.Add<ABPNavigationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ABPWebMvcModule).GetAssembly());
        }
    }
}
