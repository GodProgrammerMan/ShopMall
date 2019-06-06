using IdentityServer4.AccessTokenValidation;
using log4net;
using log4net.Config;
using log4net.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using ShopMall.Common;
using AutoMapper;
using ShopMall.Common.Log;
using ShopMall.Common.MemoryCache;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;
using WebAPI.Authorization;
using WebAPI.FilterClass;
using StackExchange.Profiling.Storage;
using System;
using static WebAPI.SwaggerHelper.CustomApiVersion;
using System.Linq;
using Newtonsoft.Json.Serialization;
using ShopMall.Common.HttpContextUser;
using Microsoft.AspNetCore.Http;
using Autofac.Extensions.DependencyInjection;
using Autofac;
using WebAPI.AOP;
using System.Reflection;
using System.Collections.Generic;
using ShopMall.Common.Helper;
using Autofac.Extras.DynamicProxy;
using WebAPI.Middlewares;

namespace WebAPI
{
    /// <summary>
    /// 程序启动
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 跨域自定义名
        /// </summary>
        public const string CorsName = "WebApiCors";
        /// <summary>
        /// 接口名称
        /// </summary>
        public string webapiName = "ShoppingMall";

        /// <summary>
        /// 定义配置
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// log4net 仓储库
        /// </summary>
        public static ILoggerRepository repository { get; set; }
        /// <summary>
        /// 启动类构造，方便初始化所需对象
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;//初始化配置
            //log4net
            repository = LogManager.CreateRepository(Configuration["Logging:Log4Net:Name"]);
            //指定配置文件，如果这里你遇到问题，应该是使用了InProcess模式，请查看Blog.Core.csproj,并删之
            XmlConfigurator.Configure(repository, new FileInfo("log4net.config"));
        }

        /// <summary>
        /// 注入服务
        /// </summary>
        /// <param name="services"></param>
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            #region 数据缓存与log4日志注入
            // 缓存注入
            services.AddScoped<ICaching, MemoryCaching>();
            services.AddSingleton<IMemoryCache>(factory =>
            {
                var cache = new MemoryCache(new MemoryCacheOptions());
                return cache;
            });
            // Redis注入
            services.AddSingleton<IRedisCacheManager, RedisCacheManager>();
            // log日志注入
            services.AddSingleton<ILoggerHelper, LogHelper>();

            //添加过滤器，方便处理权限问题
            services.AddMvcCore(option =>
            {
                option.Filters.Add(new TestAuthorizationFilter());
            }).AddAuthorization()
    .AddJsonFormatters();
            #endregion

            #region 初始化连接DB
            services.AddScoped<ShopMall.Model.Models.DBSeed>();
            #endregion

            #region 添加映射Automapper
            services.AddAutoMapper(typeof(Startup));
            #endregion 

            //跨域处理，正式环境在处理
            services.AddCors(op => { op.AddPolicy(CorsName, set => { set.SetIsOriginAllowed(origin => true).AllowAnyHeader().AllowAnyMethod().AllowCredentials(); }); });

            #region 使用MiniProfiler进行性能分析，注入MiniProfiler
            services.AddMiniProfiler(options =>
            {
                options.RouteBasePath = "/profiler";
                (options.Storage as MemoryCacheStorage).CacheDuration = TimeSpan.FromMinutes(10);
            }
            );
            #endregion

            #region Swagger UI 处理
            var basePath = PlatformServices.Default.Application.ApplicationBasePath;
            services.AddSwaggerGen(options =>
                {
                    options.OperationFilter<AuthTokenHeaderParameter>();
                    options.DocumentFilter<AuthApplyTagDescriptions>();

                    typeof(ApiVersions).GetEnumNames().ToList().ForEach(version =>
                    {
                        options.SwaggerDoc(version, new Info
                        {
                            // 定义成全局变量，方便修改
                            Version = version,
                            Title = $"{webapiName} 接口文档",
                            Description = $"{webapiName} HTTP API " + version,
                            TermsOfService = "None",
                            Contact = new Contact { Name = "webapi", Email = "960842214@qq.com", Url = "https://imlzx.cn" }
                        });
                        options.OrderActionsBy(o => o.RelativePath);
                    });

                    var xmlPath = Path.Combine(basePath, "WebAPI.xml");
                    options.IncludeXmlComments(xmlPath,true);

                    var xmlModelPath = Path.Combine(basePath, "ShopMall.Model.xml");//这个就是Model层的xml文件名
                    options.IncludeXmlComments(xmlModelPath);

                });
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
                o.Conventions.Insert(0, new GlobalRouteAuthorizeConvention());
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
            // 取消默认驼峰
            .AddJsonOptions(options => { options.SerializerSettings.ContractResolver = new DefaultContractResolver(); });
            #endregion

            #region Httpcontext
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, AspNetUser>();
            #endregion

            #region IdentityServer4 验证
            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = "http://lzxidentityserver.com/";
                    options.RequireHttpsMetadata = false;
                    options.ApiName = "api1";
                });
            #endregion


            #region AutoFac DI
            //实例化 AutoFac  容器   
            var builder = new ContainerBuilder();
            //注册要通过反射创建的组件
            //builder.RegisterType<AdvertisementServices>().As<IAdvertisementServices>();
            builder.RegisterType<ShopMallCacheAOP>();//可以直接替换其他拦截器
            builder.RegisterType<ShopMallRedisCacheAOP>();//可以直接替换其他拦截器
            builder.RegisterType<ShopMallLogAOP>();//这样可以注入第二个

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
                if (Appsettings.app(new string[] { "AppSettings", "RedisCaching", "Enabled" }).ObjToBool())
                {
                    cacheType.Add(typeof(ShopMallCacheAOP));
                }
                if (Appsettings.app(new string[] { "AppSettings", "MemoryCachingAOP", "Enabled" }).ObjToBool())
                {
                    cacheType.Add(typeof(ShopMallRedisCacheAOP));
                }
                if (Appsettings.app(new string[] { "AppSettings", "LogAOP", "Enabled" }).ObjToBool())
                {
                    cacheType.Add(typeof(ShopMallLogAOP));
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
                throw new Exception("※※★※※ 如果你是第一次下载项目，请先对整个解决方案dotnet build（F6编译），然后再对api层 dotnet run（F5执行），\n因为解耦了，如果你是发布的模式，请检查bin文件夹是否存在Repository.dll和service.dll ※※★※※"+e);
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

        /// <summary>
        /// 注入中间管道
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (Appsettings.app("AppSettings", "Middleware_RequestResponse", "Enabled").ObjToBool())
            {
                app.UseReuestResponseLog();//记录请求与返回数据 
            } 

            if (env.IsDevelopment())
            {
                // 在开发环境中，使用异常页面，这样可以暴露错误堆栈信息，所以不要放在生产环境。
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // 在非开发环境中，使用HTTP严格安全传输(or HSTS) 对于保护web安全是非常重要的。
                // 强制实施 HTTPS 在 ASP.NET Core，配合 app.UseHttpsRedirection
                //app.UseHsts();
                app.UseHsts();
            }

            #region SwaggerUI 注入
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                //根据版本名称倒序 遍历展示
                typeof(ApiVersions).GetEnumNames().OrderByDescending(e => e).ToList().ForEach(version =>
                {
                    c.SwaggerEndpoint($"/swagger/{version}/swagger.json", $"{webapiName} {version}");
                });
                // 将swagger首页，设置成我们自定义的页面，记得这个字符串的写法：解决方案名.index.html
                c.IndexStream = () => GetType().GetTypeInfo().Assembly.GetManifestResourceStream("ShoppingMall.index.html");//这里是配合MiniProfiler进行性能监控的，《文章：完美基于AOP的接口性能分析》，如果你不需要，可以暂时先注释掉，不影响大局。
                c.RoutePrefix = ""; //路径配置，设置为空，表示直接在根域名（localhost:8001）访问该文件,注意localhost:8001/swagger是访问不到的，去launchSettings.json把launchUrl去掉
                //c.InjectJavascript("/js/zh_CN.js"); // 加载中文包
                //c.SwaggerEndpoint("/swagger/v1/swagger.json", "ShoppingMall V1");
            });
            #endregion

            #region MiniProfiler
            app.UseMiniProfiler();
            #endregion

            app.UseAuthentication();


            // 设置允许所有来源跨域
            app.UseCors(CorsName);


            app.UseHttpsRedirection();
            app.UseStaticFiles();
            // 使用cookie
            app.UseCookiePolicy();

            app.UseMvc();
        }
    }
}
