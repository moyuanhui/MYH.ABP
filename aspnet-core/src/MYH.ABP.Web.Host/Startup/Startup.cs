using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Castle.Facilities.Logging;
using Swashbuckle.AspNetCore.Swagger;
using Abp.AspNetCore;
using Abp.Castle.Logging.Log4Net;
using Abp.Extensions;
using MYH.ABP.Authentication.JwtBearer;
using MYH.ABP.Configuration;
using MYH.ABP.Identity;
using System.IO;

#if FEATURE_SIGNALR
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using Owin;
using Abp.Owin;
using MYH.ABP.Owin;
#elif FEATURE_SIGNALR_ASPNETCORE
using Abp.AspNetCore.SignalR.Hubs;
#endif

namespace MYH.ABP.Web.Host.Startup
{
    public class Startup
    {
        private const string _defaultCorsPolicyName = "localhost";

        private readonly IConfigurationRoot _appConfiguration;
        private readonly IHostingEnvironment _env;

        public Startup(IHostingEnvironment env)
        {
            _appConfiguration = env.GetAppConfiguration();
            _env = env;
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // MVC
            services.AddMvc(
                options => options.Filters.Add(new CorsAuthorizationFilterFactory(_defaultCorsPolicyName))
            );

            IdentityRegistrar.Register(services);
            AuthConfigurer.Configure(services, _appConfiguration);

#if FEATURE_SIGNALR_ASPNETCORE
            services.AddSignalR();
#endif

            ConfigureCrosService(services);
            ConfigureSwaggerService(services);
            return  ConfigureAbpService(services);

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseAbp(options => { options.UseAbpRequestLocalization = false; }); // Initializes ABP framework.

            app.UseCors(_defaultCorsPolicyName); // Enable CORS!

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseAbpRequestLocalization();

#if FEATURE_SIGNALR
            // Integrate with OWIN
            app.UseAppBuilder(ConfigureOwinServices);
#elif FEATURE_SIGNALR_ASPNETCORE
            app.UseSignalR(routes =>
            {
                routes.MapHub<AbpCommonHub>("/signalr");
            });
#endif

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "defaultWithArea",
                    template: "{area}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            // Enable middleware to serve generated Swagger as a JSON endpoint
            app.UseSwagger();
            // Enable middleware to serve swagger-ui assets (HTML, JS, CSS etc.)
            app.UseSwaggerUI(options =>
            {
                options.InjectOnCompleteJavaScript("/swagger/ui/abp.js");
                options.InjectOnCompleteJavaScript("/swagger/ui/on-complete.js");

                //加载中文包
                options.InjectOnCompleteJavaScript("/swagger/ui/zh_CN.js");
                options.InjectStylesheet("/swagger/ui/zh_CN.css");

                options.SwaggerEndpoint("/swagger/v1/swagger.json", "MYH API V1");
            }); // URL: /swagger
        }

        /// <summary>
        /// 配置 Swagger UI 服务
        /// </summary>
        private IServiceCollection ConfigureSwaggerService(IServiceCollection services)
        {
            // 注册 Swagger UI 组件
            return services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info { Title = "MYH API", Version = "v1" });
                options.DocInclusionPredicate((docName, description) => true);

                // 使用 JWT 作为其默认验证方式
                options.AddSecurityDefinition("bearerAuth", new ApiKeyScheme()
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });

                options.DocumentFilter<SwaggerCustomUIFiliter>();               // 指定自定义文档过滤器
                options.OperationFilter<SecurityRequirementsOperationFilter>(); // 指定授权过滤器
                options.CustomSchemaIds(type => type.FullName);                 // 解决相同类名会报错的问题

                DirectoryInfo directory = new DirectoryInfo(Path.Combine(_env.ContentRootPath, "doc"));
                if (directory.Exists)
                {
                    foreach (var file in directory.GetFiles("*.xml"))
                    {
                        options.IncludeXmlComments(file.FullName);               // 标注要使用的 XML 文档
                    }
                }
            });
        }

        /// <summary>
        /// Abp框架配置
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        private IServiceProvider ConfigureAbpService(IServiceCollection services)
        {
            return services.AddAbp<ABPWebHostModule>(
                 options => options.IocManager.IocContainer.AddFacility<LoggingFacility>(
                     f => f.UseAbpLog4Net().WithConfig("log4net.config")
                 )
             );
        }


        /// <summary>
        /// 配置Cros服务
        /// </summary>
        /// <param name="services"></param>
        private void ConfigureCrosService(IServiceCollection services)
        {
            services.AddCors(
              options => options.AddPolicy(
                  _defaultCorsPolicyName,
                  builder => builder
                      .WithOrigins(
                          // App:CorsOrigins in appsettings.json can contain more than one address separated by comma.
                          _appConfiguration["App:CorsOrigins"]
                              .Split(",", StringSplitOptions.RemoveEmptyEntries)
                              .Select(o => o.RemovePostFix("/"))
                              .ToArray()
                      )
                      .AllowAnyHeader()
                      .AllowAnyMethod()
              )
          );
        }

#if FEATURE_SIGNALR
        private static void ConfigureOwinServices(IAppBuilder app)
        {
            app.Properties["host.AppName"] = "ABP";

            app.UseAbp();
            
            app.Map("/signalr", map =>
            {
                map.UseCors(CorsOptions.AllowAll);
                var hubConfiguration = new HubConfiguration
                {
                    EnableJSONP = true
                };
                map.RunSignalR(hubConfiguration);
            });
        }
#endif
    }
}
