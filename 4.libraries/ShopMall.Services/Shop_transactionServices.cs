
	//----------Shop_transaction开始----------
    

using System;
using ShopMall.IServices;
using ShopMall.IRepository;
using ShopMall.Model.Models;
using ShopMall.Services.BASE;
namespace ShopMall.Services
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
	