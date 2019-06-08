using Castle.DynamicProxy;
using Microsoft.AspNetCore.SignalR;
using ShopMall.Common.Hubs;
using ShopMall.Common.LogHelper;
using StackExchange.Profiling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.AOP
{
    /// <summary>
    /// 拦截器ShopMallLogAOP 继承IInterceptor接口
    /// </summary>
    public class ShopMallLogAOP : IInterceptor
    {
        private readonly IHubContext<ChatHub> _hubContext;
        public ShopMallLogAOP(IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;

        }

        /// <summary>
        /// 实例化IInterceptor唯一方法 
        /// </summary>
        /// <param name="invocation">包含被拦截方法的信息</param>
        public void Intercept(IInvocation invocation)
        {
            //记录被拦截方法信息的日志信息
            var dataIntercept = "" +
                $"【当前执行方法】：{ invocation.Method.Name} \r\n" +
                $"【携带的参数有】： {string.Join(", ", invocation.Arguments.Select(a => (a ?? "").ToString()).ToArray())} \r\n";

            try
            {
                MiniProfiler.Current.Step($"执行Service方法：{invocation.Method.Name}() -> ");
                //在被拦截的方法执行完毕后 继续执行当前方法，注意是被拦截的是异步的
                invocation.Proceed();
            }
            catch (Exception e)
            {
                //执行的 service 中，收录异常
                MiniProfiler.Current.CustomTiming("Errors：", e.Message);
                //执行的 service 中，捕获异常
                dataIntercept += ($"方法执行中出现异常：{e.Message + e.InnerException}\r\n");
            }

            dataIntercept += ($"【执行完成结果】：{invocation.ReturnValue}");

            Parallel.For(0, 1, e =>
            {
                LogLock log = new LogLock();
                LogLock.OutSql2Log("AOPLog", new string[] { dataIntercept });
            });

            _hubContext.Clients.All.SendAsync("ReceiveUpdate", LogLock.GetLogData()).Wait();


        }

    }
}
