
	//----------Shop_orderItem开始----------
    

using System;
using ShopMall.IServices;
using ShopMall.IRepository;
using ShopMall.Model.Models;
using ShopMall.Services.BASE;
namespace ShopMall.Services
{	
	/// <summary>
	/// Shop_orderItemServices
	/// </summary>	
	public class Shop_orderItemServices : BaseServices<Shop_orderItem>, IShop_orderItemServices
    {
	
        IShop_orderItemRepository dal;
        public Shop_orderItemServices(IShop_orderItemRepository dal)
        {
            this.dal = dal;
            base.baseDal = dal;
        }
       
    }
}

	//----------Shop_orderItem结束----------
	