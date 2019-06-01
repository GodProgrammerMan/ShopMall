using PushService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PushService
{
    public interface IShopClient
    {
        Task SayHello(HubMessageModel model);
        Task messageconnect(byte[] message);
    }



}
