using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;
using WebAPI.Authorization;
using WebAPI.FilterClass;

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
        /// 定义配置
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// 获取目录
        /// </summary>
        public string basePath = PlatformServices.Default.Application.ApplicationBasePath;

        /// <summary>
        /// 启动类构造，方便初始化所需对象
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;//初始化配置
        }

        /// <summary>
        /// 注入服务
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddMvcCore(option =>
            {
                option.Filters.Add(new TestAuthorizationFilter());
            }).AddAuthorization()
    .AddJsonFormatters();

            services.AddCors(op => { op.AddPolicy(CorsName, set => { set.SetIsOriginAllowed(origin => true).AllowAnyHeader().AllowAnyMethod().AllowCredentials(); }); });

            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication(options =>  
                {
                    options.Authority = "http://lzxidentityserver.com/";
                    options.RequireHttpsMetadata = false;
                    options.ApiName = "api1";
                });
           
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(options =>
            {
                options.OperationFilter<AuthTokenHeaderParameter>();
                options.DocumentFilter<AuthApplyTagDescriptions>();
                options.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "ShoppingMall API"
                });
 
                var xmlPath = Path.Combine(basePath, "WebAPI.xml");
                options.IncludeXmlComments(xmlPath);
            });
        }

        /// <summary>
        /// 注入中间管道
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseAuthentication();
            // 设置允许所有来源跨域
            app.UseCors(CorsName);

            app.UseHttpsRedirection();

            app.UseMvc();

            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI(c => 
            {
                var _swahherjs = Path.Combine(basePath, "zh_CN.js");
                c.InjectJavascript("/js/zh_CN.js"); // 加载中文包
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ShoppingMall V1");
            }); 

        }
    }
}
