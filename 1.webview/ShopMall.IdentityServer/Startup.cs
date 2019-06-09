using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;
using log4net;
using log4net.Config;
using log4net.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Newtonsoft.Json.Serialization;
using ShopMall.Common;
using ShopMall.Common.Helper;
using ShopMall.Common.Log;
using ShopMall.IdentityServer.AOP;
using ShopMall.IdentityServer.FilterHelper;
using ShopMall.IdentityServer.IdsConfig;

namespace ShopMall.IdentityServer
{
    public class Startup
    {
        public const string CorsName = "CorsIdentity";

        public IConfiguration Configuration { get; }

        /// <summary>
        /// log4net 仓储库
        /// </summary>
        public static ILoggerRepository repository { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Configuration = configuration;//初始化配置
            //log4net
            repository = LogManager.CreateRepository(Configuration["Logging:Log4Net:Name"]);
            //指定配置文件，如果这里你遇到问题，应该是使用了InProcess模式，请查看Blog.Core.csproj,并删之
            XmlConfigurator.Configure(repository, new FileInfo("log4net.config"));
        }


        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // Redis注入
            services.AddSingleton<IRedisCacheManager, RedisCacheManager>();
            // log日志注入
            services.AddSingleton<ILoggerHelper, LogHelper>();


            #region 初始化连接DB
            services.AddScoped<ShopMall.Model.Models.DBSeed>();
            #endregion

            #region IdentityServer4
            services.AddIdentityServer()
                          .AddDeveloperSigningCredential()
                          .AddInMemoryIdentityResources(Config.GetIdentityResourceResources())
                          .AddInMemoryApiResources(Config.GetApiResources())
                          .AddInMemoryClients(Config.GetClients())
                          .AddResourceOwnerValidator<ResourceOwnerPasswordValidator>()
                          .AddProfileService<ProfileService>();
            services.AddCors(op => { op.AddPolicy(CorsName, set => { set.SetIsOriginAllowed(origin => true).AllowAnyHeader().AllowAnyMethod().AllowCredentials(); }); });
            #endregion

            #region MVC + GlobalExceptions
            //注入全局异常捕获
            services.AddMvc(o =>
            {
                // 全局异常过滤
                o.Filters.Add(typeof(GlobalExceptionsFilter));
                // 全局权限过滤【无效】
                //o.Filters.Add(typeof(MyAuthorizeFilter));
                // 全局路由权限公约
                //o.Conventions.Insert(0, new GlobalRouteAuthorizeConvention());
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
            // 取消默认驼峰
            .AddJsonOptions(options => { options.SerializerSettings.ContractResolver = new DefaultContractResolver(); });
            #endregion

            #region AutoFac DI
            var basePath = PlatformServices.Default.Application.ApplicationBasePath;
            //实例化 AutoFac  容器   
            var builder = new ContainerBuilder();
            //注册要通过反射创建的组件
            builder.RegisterType<ShopMallRedisCacheAOP>();//可以直接替换其他拦截器

            #region 带有接口层的服务注入

            #region Service.dll 注入，有对应接口
            //获取项目绝对路径，请注意，这个是实现类的dll文件，不是接口 IService.dll ，注入容器当然是Activatore
            try
            {
                var servicesDllFile = Path.Combine(basePath, "ShopMall.Services.dll");
                var assemblysServices = Assembly.LoadFrom(servicesDllFile);//直接采用加载文件的方法  

                //builder.RegisterAssemblyTypes(assemblysServices).AsImplementedInterfaces();//指定已扫描程序集中的类型注册为提供所有其实现的接口。


                // AOP 开关，如果想要打开指定的功能，只需要在 appsettigns.json 对应对应 true 就行。
                var cacheType = new List<Type>();
                if (Appsettings.app(new string[] { "AppSettings", "MemoryCachingAOP", "Enabled" }).ObjToBool())
                {
                    cacheType.Add(typeof(ShopMallRedisCacheAOP));
                }

                builder.RegisterAssemblyTypes(assemblysServices)
                          .AsImplementedInterfaces()
                          .InstancePerLifetimeScope()
                          .EnableInterfaceInterceptors()//引用Autofac.Extras.DynamicProxy;
                                                        // 如果你想注入两个，就这么写  InterceptedBy(typeof(BlogCacheAOP), typeof(BlogLogAOP));
                                                        // 如果想使用Redis缓存，请必须开启 redis 服务，端口号我的是6319，如果不一样还是无效，否则请使用memory缓存 BlogCacheAOP
                          .InterceptedBy(cacheType.ToArray());//允许将拦截器服务的列表分配给注册。 
                #endregion

                #region Repository.dll 注入，有对应接口
                var repositoryDllFile = Path.Combine(basePath, "ShopMall.Repository.dll");
                var assemblysRepository = Assembly.LoadFrom(repositoryDllFile);
                builder.RegisterAssemblyTypes(assemblysRepository).AsImplementedInterfaces();
            }
            catch (Exception e)
            {
                throw new Exception("※※★※※ 如果你是第一次下载项目，请先对整个解决方案dotnet build（F6编译），然后再对api层 dotnet run（F5执行），\n因为解耦了，如果你是发布的模式，请检查bin文件夹是否存在Repository.dll和service.dll ※※★※※" + e);
            }
            #endregion
            #endregion


            #region 没有接口层的服务层注入

            ////因为没有接口层，所以不能实现解耦，只能用 Load 方法。
            ////var assemblysServicesNoInterfaces = Assembly.Load("Blog.Core.Services");
            ////builder.RegisterAssemblyTypes(assemblysServicesNoInterfaces);

            #endregion

            #region 没有接口的单独类 class 注入
            ////只能注入该类中的虚方法
            //builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(Love)))
            //    .EnableClassInterceptors()
            //    .InterceptedBy(typeof(BlogLogAOP));
            #endregion


            //将services填充到Autofac容器生成器中
            builder.Populate(services);

            //使用已进行的组件登记创建新容器
            var ApplicationContainer = builder.Build();

            #endregion

            return new AutofacServiceProvider(ApplicationContainer);//第三方IOC接管 core内置DI容器
        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseCors(CorsName);
            app.UseIdentityServer();

            app.UseMvc();
        }
    }
}
