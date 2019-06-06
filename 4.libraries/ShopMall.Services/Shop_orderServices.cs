
	//----------Shop_order开始----------
    

using System;
using ShopMall.IServices;
using ShopMall.IRepository;
using ShopMall.Model.Models;
using ShopMall.Services.BASE;
namespace ShopMall.Services
{	
	/// <summary>
	/// Shop_orderServices
	/// </summary>	
	public class Shop_orderServices : BaseServices<Shop_order>, IShop_orderServices
    {
	
        IShop_orderRepository dal;
        public Shop_orderServices(IShop_orderRepository dal)
        {
            this.dal = dal;
            base.baseDal = dal;
        }
       
    }
}

	//----------Shop_order结束----------
	