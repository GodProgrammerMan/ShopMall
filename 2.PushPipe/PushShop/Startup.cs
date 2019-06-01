using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PushShop.HubClass;

namespace PushShop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // 注入服务
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSignalR();
            services.AddCors(op => { op.AddPolicy("cors", set => { set.SetIsOriginAllowed(origin => true).AllowAnyHeader().AllowAnyMethod().AllowCredentials(); }); });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // 注入中间管道
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
            // 设置允许所有来源跨域
            app.UseCors("cors");

            app.UseSignalR(opt =>
            {
                opt.MapHub<PushServiceHub>("/hubService");
            });



            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
