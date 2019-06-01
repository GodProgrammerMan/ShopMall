using Microsoft.AspNetCore.SignalR;
using PushShop.Interface;
using PushShop.Model;
using System;
using System.Threading.Tasks;

namespace PushShop.HubClass
{
    public class PushServiceHub : Hub<IShopClient>
    {
        public Task SendMessage(string user, string message)
        {
            return Clients.All.SayHello(new HubMessageModel()
            {
                UserName = user,
                Message = message
            });
        }

        //已连接
        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }


        //失去连接
        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
    }
}
