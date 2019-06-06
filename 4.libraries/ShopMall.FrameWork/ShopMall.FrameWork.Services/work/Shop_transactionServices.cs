
	//----------Shop_transaction开始----------
    

using System;
using ShopMall.FrameWork.IServices;
using ShopMall.FrameWork.IRepository;
using ShopMall.FrameWork.Entity;

namespace ShopMall.FrameWork.Services
{	
	/// <summary>
	/// Shop_transactionServices
	/// </summary>	
	public class Shop_transactionServices : BaseServices<Shop_transaction>, IShop_transactionServices
    {
	
        IShop_transactionRepository dal;
        public Shop_transactionServices(IShop_transactionRepository dal)
        {
            this.dal = dal;
            base.baseDal = dal;
        }
       
    }
}

	//----------Shop_transaction结束----------
	