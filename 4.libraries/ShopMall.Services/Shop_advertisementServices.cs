
	//----------Shop_advertisement开始----------
    

using System;
using ShopMall.IServices;
using ShopMall.IRepository;
using ShopMall.Model.Models;
using ShopMall.Services.BASE;
namespace ShopMall.Services
{	
	/// <summary>
	/// Shop_advertisementServices
	/// </summary>	
	public class Shop_advertisementServices : BaseServices<Shop_advertisement>, IShop_advertisementServices
    {
	
        IShop_advertisementRepository dal;
        public Shop_advertisementServices(IShop_advertisementRepository dal)
        {
            this.dal = dal;
            base.baseDal = dal;
        }
       
    }
}

	//----------Shop_advertisement结束----------
	