using PushShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PushShop.Interface
{
    public interface IShopClient
    {
        Task SayHello(HubMessageModel model);
        Task SetPosition(PositionMolde model);
    }
}
