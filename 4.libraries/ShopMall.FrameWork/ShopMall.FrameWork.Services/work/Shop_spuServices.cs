
	//----------Shop_spu开始----------
    

using System;
using ShopMall.FrameWork.IServices;
using ShopMall.FrameWork.IRepository;
using ShopMall.FrameWork.Entity;

namespace ShopMall.FrameWork.Services
{	
	/// <summary>
	/// Shop_spuServices
	/// </summary>	
	public class Shop_spuServices : BaseServices<Shop_spu>, IShop_spuServices
    {
	
        IShop_spuRepository dal;
        public Shop_spuServices(IShop_spuRepository dal)
        {
            this.dal = dal;
            base.baseDal = dal;
        }
       
    }
}

	//----------Shop_spu结束----------
	