//----------Shop_code开始----------


using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ShopMall.IServices.BASE;
using ShopMall.Model.Models;

namespace ShopMall.IServices
{
    /// <summary>
    /// Shop_codeServices
    /// </summary>	
    public interface IShop_codeServices : IBaseServices<Shop_code>
    {
        Task<bool> updateCodeStatus(string code);
        Task<Shop_code> QueryByLately(Expression<Func<Shop_code, bool>> whereExpression);
    }
}

	//----------Shop_code结束----------
	