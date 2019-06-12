	//----------Shop_code开始----------
    

using System;
using ShopMall.FrameWork.IServices;
using ShopMall.FrameWork.IRepository;
using ShopMall.FrameWork.Entity;

namespace ShopMall.FrameWork.Services
{	
	/// <summary>
	/// Shop_codeServices
	/// </summary>	
	public class Shop_codeServices : BaseServices<Shop_code>, IShop_codeServices
    {
	
        IShop_codeRepository dal;
        public Shop_codeServices(IShop_codeRepository dal)
        {
            this.dal = dal;
            base.baseDal = dal;
        }
       
    }
}

	//----------Shop_code结束----------
	