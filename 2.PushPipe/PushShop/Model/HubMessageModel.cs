using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PushShop.Model
{
    public class HubMessageModel
    {
        public string UserName { get; set; }
        public string Message { get; set; }
    }
    public class PositionMolde {
        public string longitude { get; internal set; }
        public string latitude { get; internal set; }
    }
}
