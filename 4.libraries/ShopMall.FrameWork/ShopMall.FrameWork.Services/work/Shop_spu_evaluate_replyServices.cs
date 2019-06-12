	//----------Shop_spu_evaluate_reply开始----------
    

using System;
using ShopMall.FrameWork.IServices;
using ShopMall.FrameWork.IRepository;
using ShopMall.FrameWork.Entity;

namespace ShopMall.FrameWork.Services
{	
	/// <summary>
	/// Shop_spu_evaluate_replyServices
	/// </summary>	
	public class Shop_spu_evaluate_replyServices : BaseServices<Shop_spu_evaluate_reply>, IShop_spu_evaluate_replyServices
    {
	
        IShop_spu_evaluate_replyRepository dal;
        public Shop_spu_evaluate_replyServices(IShop_spu_evaluate_replyRepository dal)
        {
            this.dal = dal;
            base.baseDal = dal;
        }
       
    }
}

	//----------Shop_spu_evaluate_reply结束----------
	