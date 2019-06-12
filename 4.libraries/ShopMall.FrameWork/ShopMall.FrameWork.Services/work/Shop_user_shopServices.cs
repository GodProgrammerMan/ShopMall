	//----------Shop_user_shop开始----------
    

using System;
using ShopMall.FrameWork.IServices;
using ShopMall.FrameWork.IRepository;
using ShopMall.FrameWork.Entity;

namespace ShopMall.FrameWork.Services
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
	