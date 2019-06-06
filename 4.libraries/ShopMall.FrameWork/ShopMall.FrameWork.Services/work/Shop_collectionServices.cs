
	//----------Shop_collection开始----------
    

using System;
using ShopMall.FrameWork.IServices;
using ShopMall.FrameWork.IRepository;
using ShopMall.FrameWork.Entity;

namespace ShopMall.FrameWork.Services
{	
	/// <summary>
	/// Shop_collectionServices
	/// </summary>	
	public class Shop_collectionServices : BaseServices<Shop_collection>, IShop_collectionServices
    {
	
        IShop_collectionRepository dal;
        public Shop_collectionServices(IShop_collectionRepository dal)
        {
            this.dal = dal;
            base.baseDal = dal;
        }
       
    }
}

	//----------Shop_collection结束----------
	