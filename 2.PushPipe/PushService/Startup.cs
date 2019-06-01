using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using PushService.HubClass;
using System;
using System.Threading.Tasks;

namespace PushService
{
    public class Startup
    {
        public const string CorsName = "SignalRCors";

        //向应用程序注入服务
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddSignalR();
            services.AddCors(op => { op.AddPolicy(CorsName, set => { set.SetIsOriginAllowed(origin => true).AllowAnyHeader().AllowAnyMethod().AllowCredentials(); }); });
        }

        // 注入中间插件
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


            app.UseCors(CorsName);

            app.UseSignalR(opt =>
            {
                opt.MapHub<PushServiceHub>("/hubService");

            });
        }
    }
}
