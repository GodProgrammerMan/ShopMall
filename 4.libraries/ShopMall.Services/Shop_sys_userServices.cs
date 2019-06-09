
//----------Shop_sys_user开始----------


using System;
using ShopMall.IServices;
using ShopMall.IRepository;
using ShopMall.Model.Models;
using ShopMall.Services.BASE;
using System.Threading.Tasks;

namespace ShopMall.Services
{	
	/// <summary>
	/// Shop_sys_userServices
	/// </summary>	
	public class Shop_sys_userServices : BaseServices<Shop_sys_user>, IShop_sys_userServices
    {
	
        IShop_sys_userRepository dal;
        public Shop_sys_userServices(IShop_sys_userRepository dal)
        {
            this.dal = dal;
            base.baseDal = dal;
        }

        public async Task<Shop_sys_user> GetSysUserByLoginNameAsync(string loginName)
        {
            Shop_sys_user model = null;

            if (!string.IsNullOrWhiteSpace(loginName))
            {
                model = await dal.GetSysUserByLoginName(loginName);
            }

            return model;
        }
    }
}

	