
	//----------Shop_spu_evaluate_img开始----------
    

using System;
using ShopMall.FrameWork.IServices;
using ShopMall.FrameWork.IRepository;
using ShopMall.FrameWork.Entity;

namespace ShopMall.FrameWork.Services
{	
	/// <summary>
	/// Shop_spu_evaluate_imgServices
	/// </summary>	
	public class Shop_spu_evaluate_imgServices : BaseServices<Shop_spu_evaluate_img>, IShop_spu_evaluate_imgServices
    {
	
        IShop_spu_evaluate_imgRepository dal;
        public Shop_spu_evaluate_imgServices(IShop_spu_evaluate_imgRepository dal)
        {
            this.dal = dal;
            base.baseDal = dal;
        }
       
    }
}

	//----------Shop_spu_evaluate_img结束----------
	