
	//----------Shop_spu_evaluate开始----------
    

using System;
using ShopMall.IServices;
using ShopMall.IRepository;
using ShopMall.Model.Models;
using ShopMall.Services.BASE;
namespace ShopMall.Services
{	
	/// <summary>
	/// Shop_spu_evaluateServices
	/// </summary>	
	public class Shop_spu_evaluateServices : BaseServices<Shop_spu_evaluate>, IShop_spu_evaluateServices
    {
	
        IShop_spu_evaluateRepository dal;
        public Shop_spu_evaluateServices(IShop_spu_evaluateRepository dal)
        {
            this.dal = dal;
            base.baseDal = dal;
        }
       
    }
}

	//----------Shop_spu_evaluate结束----------
	