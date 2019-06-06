
	//----------Shop_address开始----------
    

using System;
using ShopMall.IServices;
using ShopMall.IRepository;
using ShopMall.Model.Models;
using ShopMall.Services.BASE;

namespace ShopMall.Services
{	
	/// <summary>
	/// Shop_addressServices
	/// </summary>	
	public class Shop_addressServices : BaseServices<Shop_address>, IShop_addressServices
    {
	
        IShop_addressRepository dal;
        public Shop_addressServices(IShop_addressRepository dal)
        {
            this.dal = dal;
            base.baseDal = dal;
        }
       
    }
}

	//----------Shop_address结束----------
	