
	
using System;
using System.Threading.Tasks;
using ShopMall.IRepository.BASE;
using ShopMall.Model.Models;
namespace ShopMall.IRepository
{
    /// <summary>
    /// IShop_user_logRepository
    /// </summary>	
    public interface IShop_user_logRepository : IBaseRepository<Shop_user_log>//类名
    {
        Task UpdateUserLoginAsync(int uid);
    }
}

	//----------Shop_user_log结束----------
	