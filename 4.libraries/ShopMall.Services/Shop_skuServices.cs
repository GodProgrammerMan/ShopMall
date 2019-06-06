
	//----------Shop_sku开始----------
    

using System;
using ShopMall.IServices;
using ShopMall.IRepository;
using ShopMall.Model.Models;
using ShopMall.Services.BASE;
namespace ShopMall.Services
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
	