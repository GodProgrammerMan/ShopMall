
	//----------Shop_user_log开始----------
    

using System;
using ShopMall.FrameWork.IServices;
using ShopMall.FrameWork.IRepository;
using ShopMall.FrameWork.Entity;

namespace ShopMall.FrameWork.Services
{	
	/// <summary>
	/// Shop_user_logServices
	/// </summary>	
	public class Shop_user_logServices : BaseServices<Shop_user_log>, IShop_user_logServices
    {
	
        IShop_user_logRepository dal;
        public Shop_user_logServices(IShop_user_logRepository dal)
        {
            this.dal = dal;
            base.baseDal = dal;
        }
       
    }
}

	//----------Shop_user_log结束----------
	