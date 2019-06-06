
	//----------Shop_refund开始----------
    

using System;
using ShopMall.IServices;
using ShopMall.IRepository;
using ShopMall.Model.Models;
using ShopMall.Services.BASE;
namespace ShopMall.Services
{	
	/// <summary>
	/// Shop_refundServices
	/// </summary>	
	public class Shop_refundServices : BaseServices<Shop_refund>, IShop_refundServices
    {
	
        IShop_refundRepository dal;
        public Shop_refundServices(IShop_refundRepository dal)
        {
            this.dal = dal;
            base.baseDal = dal;
        }
       
    }
}

	//----------Shop_refund结束----------
	