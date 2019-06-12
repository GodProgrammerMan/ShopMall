//----------Shop_code开始----------


using System;
using ShopMall.IServices;
using ShopMall.IRepository;
using ShopMall.Model.Models;
using ShopMall.Services.BASE;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace ShopMall.Services
{	
	/// <summary>
	/// Shop_codeServices
	/// </summary>	
	public class Shop_codeServices : BaseServices<Shop_code>, IShop_codeServices
    {
	
        IShop_codeRepository dal;
        public Shop_codeServices(IShop_codeRepository dal)
        {
            this.dal = dal;
            base.baseDal = dal;
        }

        public async Task<Shop_code> QueryByLately(Expression<Func<Shop_code, bool>> whereExpression)
        {
            return await dal.QueryByLately(whereExpression);
        }

        public async Task<bool> updateCodeStatus(string code,string Toname)
        {
            return await dal.updateCodeStatus(code, Toname);
        }
    }
}