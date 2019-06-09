
	//----------Shop_sys_user开始----------
    

using System;
using System.Threading.Tasks;
using ShopMall.IRepository;
using ShopMall.Model.Models;
using ShopMall.Repository.BASE;
namespace ShopMall.Repository
{
    /// <summary>
    /// Shop_sys_userRepository
    /// </summary>	
    public class Shop_sys_userRepository : BaseRepository<Shop_sys_user>, IShop_sys_userRepository
    {
        public async Task<Shop_sys_user> GetSysUserByLoginName(string loginName)
        {
            return await Task.Run(() => Db.Queryable<Shop_sys_user>().WhereIF(!string.IsNullOrWhiteSpace(loginName),t=>t.loginName == loginName).First());
        }
    }
}

	