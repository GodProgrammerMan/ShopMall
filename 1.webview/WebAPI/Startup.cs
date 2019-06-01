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
    public class Startup
    {
        public const string CorsName = "WebApiCors";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

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
                //Determine base path for the application.  
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, "WebAPI.xml");
                options.IncludeXmlComments(xmlPath);
            });
        }

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

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.InjectJavascript("/zh_CN.js"); // 加载中文包
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ShoppingMall V1");
            });

        }
    }
}
