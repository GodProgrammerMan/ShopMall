
	//----------Shop_sys_user开始----------
    
	
using System;
using ShopMall.Model.Models;
using ShopMall.IRepository.BASE;
using System.Threading.Tasks;

namespace ShopMall.IRepository
{
    /// <summary>
    /// IShop_sys_userRepository
    /// </summary>	
    public interface IShop_sys_userRepository : IBaseRepository<Shop_sys_user>//类名
    {
         Task<Shop_sys_user> GetSysUserByLoginName(string loginName);
    }
}

	//----------Shop_sys_user结束----------
	