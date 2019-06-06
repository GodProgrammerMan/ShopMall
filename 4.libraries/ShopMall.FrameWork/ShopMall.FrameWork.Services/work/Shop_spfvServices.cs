
	//----------Shop_spfv开始----------
    

using System;
using ShopMall.FrameWork.IServices;
using ShopMall.FrameWork.IRepository;
using ShopMall.FrameWork.Entity;

namespace ShopMall.FrameWork.Services
{	
	/// <summary>
	/// Shop_spfvServices
	/// </summary>	
	public class Shop_spfvServices : BaseServices<Shop_spfv>, IShop_spfvServices
    {
	
        IShop_spfvRepository dal;
        public Shop_spfvServices(IShop_spfvRepository dal)
        {
            this.dal = dal;
            base.baseDal = dal;
        }
       
    }
}

	//----------Shop_spfv结束----------
	