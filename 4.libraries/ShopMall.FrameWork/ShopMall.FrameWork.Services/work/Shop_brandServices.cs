
	//----------Shop_brand开始----------
    

using System;
using ShopMall.FrameWork.IServices;
using ShopMall.FrameWork.IRepository;
using ShopMall.FrameWork.Entity;

namespace ShopMall.FrameWork.Services
{	
	/// <summary>
	/// Shop_brandServices
	/// </summary>	
	public class Shop_brandServices : BaseServices<Shop_brand>, IShop_brandServices
    {
	
        IShop_brandRepository dal;
        public Shop_brandServices(IShop_brandRepository dal)
        {
            this.dal = dal;
            base.baseDal = dal;
        }
       
    }
}

	//----------Shop_brand结束----------
	