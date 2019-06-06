
	//----------Shop_sku开始----------
    

using System;
using ShopMall.FrameWork.IServices;
using ShopMall.FrameWork.IRepository;
using ShopMall.FrameWork.Entity;

namespace ShopMall.FrameWork.Services
{	
	/// <summary>
	/// Shop_skuServices
	/// </summary>	
	public class Shop_skuServices : BaseServices<Shop_sku>, IShop_skuServices
    {
	
        IShop_skuRepository dal;
        public Shop_skuServices(IShop_skuRepository dal)
        {
            this.dal = dal;
            base.baseDal = dal;
        }
       
    }
}

	//----------Shop_sku结束----------
	