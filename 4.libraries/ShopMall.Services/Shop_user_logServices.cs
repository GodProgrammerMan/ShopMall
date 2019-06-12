

using System;
using ShopMall.IServices;
using ShopMall.IRepository;
using ShopMall.Model.Models;
using ShopMall.Services.BASE;
using System.Threading.Tasks;

namespace ShopMall.FrameWork.Services
{	
	/// <summary>
	/// Shop_user_logServices
	/// </summary>	
	public class Shop_user_logServices : BaseServices<Shop_user_log>, IShop_user_logServices
    {
	
        IShop_user_logRepository dal;
        
        public Shop_user_logServices(IShop_user_logRepository dal)
        {
            this.dal = dal;
            base.baseDal = dal;
        }

        public async Task<bool> LoginSuccessServiceAsync(int uid, int logtype, string bcontent, string source)
        {
            //修改登录时间，和次数
            await dal.UpdateUserLoginAsync(uid);
            //添加登录记录
            return await AddUserLogAsync(uid, logtype, bcontent, source) > 1;
        }
        public async Task<int> AddUserLogAsync(int uid, int logtype, string bcontent, string source,bool iscode=false) {
            Shop_user_log _userlog = new Shop_user_log()
            {
                bcontent = bcontent,
                CreateTime = DateTime.Now,
                logType = logtype,
                source = source,
                uid = uid
            };
            return await dal.Add(_userlog);
        }
    }
}
	