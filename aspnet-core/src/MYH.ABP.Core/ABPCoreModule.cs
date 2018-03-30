using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Timing;
using Abp.Zero;
using Abp.Zero.Configuration;
using MYH.ABP.Authorization.Roles;
using MYH.ABP.Authorization.Users;
using MYH.ABP.Configuration;
using MYH.ABP.Localization;
using MYH.ABP.MultiTenancy;
using MYH.ABP.Timing;

namespace MYH.ABP
{
    /// <summary>
    /// 模块依赖
    /// 声明ABPCoreModule和AbpZeroCoreModule的依赖关系，ABPCoreModule依赖于AbpZeroCoreModule
    /// 且AbpZeroCoreModule会在ABPCoreModule之前进行初始化
    /// </summary>
    [DependsOn(typeof(AbpZeroCoreModule))]  //通过注解来定义依赖关系
    public class ABPCoreModule : AbpModule
    {

        //自定义模块方法通过构造函数注入：

        //如ModuleB依赖ModuleB，则在ModulA想嗲用ModuleB的方法，如下注入
        //private readonly ModuleB _moduleB;
        //public ModuleA(ModuleB moduleB)
        //{
        //    _moduleB = moduleB;
        //}

        //调用顺序：1
        /// <summary>
        /// 预初始化：当应用启动后，第一次运行会先调用这个方法。在初始化(Initialize)方法调用之前，该方法通常是用来配置框架以及其它模块。
        //在依赖注入注册之前，你可以在这个方法中指定你需要注入的自定义启动类。例如：加入你创建了某个符合约定的注册类，你应该使用 IocManager.AddConventionalRegisterer 方法在这里注册它。
        /// </summary>
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            // Declare entity types
            Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            Configuration.Modules.Zero().EntityTypes.User = typeof(User);

            ABPLocalizationConfigurer.Configure(Configuration.Localization);

            // Enable this line to create a multi-tenant application.
            Configuration.MultiTenancy.IsEnabled = ABPConsts.MultiTenancyEnabled;

            // Configure roles
            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

            Configuration.Settings.Providers.Add<AppSettingProvider>();
        }

        //调用顺序：2
        /// <summary>
        /// 进行依赖注入的注册
        /// </summary>
        public override void Initialize()
        {
            //这行代码的写法基本上是不变的。它的作用是把当前程序集的特定类或接口注册到依赖注入容器中。
            IocManager.RegisterAssemblyByConvention(typeof(ABPCoreModule).GetAssembly());
        }
        //调用顺序：3
        /// <summary>
        /// 解析依赖关系
        /// </summary>
        public override void PostInitialize()
        {
            IocManager.Resolve<AppTimes>().StartupTime = Clock.Now;
        }
    }
}
