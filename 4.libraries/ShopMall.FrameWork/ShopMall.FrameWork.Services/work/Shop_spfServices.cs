
	//----------Shop_spf开始----------
    

using System;
using ShopMall.FrameWork.IServices;
using ShopMall.FrameWork.IRepository;
using ShopMall.FrameWork.Entity;

namespace ShopMall.FrameWork.Services
{	
	/// <summary>
	/// Shop_spfServices
	/// </summary>	
	public class Shop_spfServices : BaseServices<Shop_spf>, IShop_spfServices
    {
	
        IShop_spfRepository dal;
        public Shop_spfServices(IShop_spfRepository dal)
        {
            this.dal = dal;
            base.baseDal = dal;
        }
       
    }
}

	//----------Shop_spf结束----------
	