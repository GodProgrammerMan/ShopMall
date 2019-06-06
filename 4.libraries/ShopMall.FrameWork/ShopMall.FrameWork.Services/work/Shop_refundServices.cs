
	//----------Shop_refund开始----------
    

using System;
using ShopMall.FrameWork.IServices;
using ShopMall.FrameWork.IRepository;
using ShopMall.FrameWork.Entity;

namespace ShopMall.FrameWork.Services
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
	