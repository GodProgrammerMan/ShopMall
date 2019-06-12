//----------Shop_code开始----------


using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ShopMall.IRepository;
using ShopMall.Model.Models;
using ShopMall.Repository.BASE;

namespace ShopMall.Repository
{
    /// <summary>
    /// Shop_codeRepository
    /// </summary>	
    public class Shop_codeRepository : BaseRepository<Shop_code>, IShop_codeRepository
    {
        public async Task<Shop_code> QueryByLately(Expression<Func<Shop_code, bool>> whereExpression)
        {
            return await Task.Run(() => Db.Queryable<Shop_code>().Where(whereExpression).OrderBy(t=>t.creatTime,SqlSugar.OrderByType.Desc).FirstAsync());
        }

        public async Task<bool> updateCodeStatus(string code)
        {
            return await Task.Run(() => Db.Updateable<Shop_code>().WhereColumns(it => new Shop_code() { state = 1 })
         .Where(it => it.code == code).ExecuteCommand()) > 1;
        }
    }
}

	//----------Shop_code结束----------
	