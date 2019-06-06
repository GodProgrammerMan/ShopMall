
	//----------Shop_collection开始----------
    

using System;
using ShopMall.IServices;
using ShopMall.IRepository;
using ShopMall.Model.Models;
using ShopMall.Services.BASE;
namespace ShopMall.Services
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
	