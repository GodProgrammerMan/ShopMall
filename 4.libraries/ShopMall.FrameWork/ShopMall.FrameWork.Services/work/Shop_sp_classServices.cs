
	//----------Shop_sp_class开始----------
    

using System;
using ShopMall.FrameWork.IServices;
using ShopMall.FrameWork.IRepository;
using ShopMall.FrameWork.Entity;

namespace ShopMall.FrameWork.Services
{	
	/// <summary>
	/// Shop_sp_classServices
	/// </summary>	
	public class Shop_sp_classServices : BaseServices<Shop_sp_class>, IShop_sp_classServices
    {
	
        IShop_sp_classRepository dal;
        public Shop_sp_classServices(IShop_sp_classRepository dal)
        {
            this.dal = dal;
            base.baseDal = dal;
        }
       
    }
}

	//----------Shop_sp_class结束----------
	