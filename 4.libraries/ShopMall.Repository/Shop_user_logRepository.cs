using System;
using System.Threading.Tasks;
using ShopMall.IRepository;
using ShopMall.Model.Models;
using ShopMall.Repository.BASE;

namespace ShopMall.FrameWork.Repository
{
    /// <summary>
    /// Shop_user_logRepository
    /// </summary>	
    public class Shop_user_logRepository : BaseRepository<Shop_user_log>, IShop_user_logRepository
    {
        public async Task UpdateUserLoginAsync(int uid)
        {
            await Task.Run(() => Db.Updateable<Shop_sys_user>().SetColumns(it => new Shop_sys_user() { LoginNum =+ 1, LastLogin = DateTime.Now })
           .Where(it => it.uid == uid).ExecuteCommand());
        }
    }
}
