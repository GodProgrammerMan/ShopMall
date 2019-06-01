using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using PushService.Model;
using System;
using System.Threading.Tasks;

namespace PushService.HubClass
{
    [Authorize]
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

        public Task MessageConnect(byte[] message)
        {
            var connectionId = Context.ConnectionId;
            return Clients.Client(connectionId).messageconnect(message);
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
