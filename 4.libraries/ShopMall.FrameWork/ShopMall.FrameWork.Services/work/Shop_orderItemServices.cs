
	//----------Shop_orderItem开始----------
    

using System;
using ShopMall.FrameWork.IServices;
using ShopMall.FrameWork.IRepository;
using ShopMall.FrameWork.Entity;

namespace ShopMall.FrameWork.Services
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
	