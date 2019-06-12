//----------Shop_code开始----------


using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ShopMall.IRepository.BASE;
using ShopMall.Model.Models;
namespace ShopMall.IRepository
{
    /// <summary>
    /// IShop_codeRepository
    /// </summary>	
    public interface IShop_codeRepository : IBaseRepository<Shop_code>//类名
    {
        Task<bool> updateCodeStatus(string code,string Toname);
        Task<Shop_code> QueryByLately(Expression<Func<Shop_code, bool>> whereExpression);
    }
}

	//----------Shop_code结束----------
	