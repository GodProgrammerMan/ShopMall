
	//----------Shop_user_shop开始----------
    

using System;
using ShopMall.IServices;
using ShopMall.IRepository;
using ShopMall.Model.Models;
using ShopMall.Services.BASE;
namespace ShopMall.Services
{	
	/// <summary>
	/// Shop_user_shopServices
	/// </summary>	
	public class Shop_user_shopServices : BaseServices<Shop_user_shop>, IShop_user_shopServices
    {
	
        IShop_user_shopRepository dal;
        public Shop_user_shopServices(IShop_user_shopRepository dal)
        {
            this.dal = dal;
            base.baseDal = dal;
        }
       
    }
}

	//----------Shop_user_shop结束----------
	