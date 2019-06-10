

using System;
using System.Threading.Tasks;
using ShopMall.IServices.BASE;
using ShopMall.Model.Models;

namespace ShopMall.IServices
{
    /// <summary>
    /// Shop_user_logServices
    /// </summary>	
    public interface IShop_user_logServices : IBaseServices<Shop_user_log>
    {
        void LoginSuccessServiceAsync(int uid, int logtype, string bcontent, string source);
        Task<int> AddUserLogAsync(int uid, int logtype, string bcontent, string source);
    }
}

	//----------Shop_user_log结束----------
	