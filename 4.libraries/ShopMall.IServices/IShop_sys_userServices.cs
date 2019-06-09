
//----------Shop_sys_user开始----------


using System;
using ShopMall.Model.Models;
using ShopMall.IServices.BASE;
using System.Threading.Tasks;

namespace ShopMall.IServices
{
    /// <summary>
    /// Shop_sys_userServices
    /// </summary>	
    public interface IShop_sys_userServices : IBaseServices<Shop_sys_user>
    {
        Task<Shop_sys_user> GetSysUserByLoginNameAsync(string loginName);
    }
}

	