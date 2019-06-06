
    
	//----------开始----------
	
using System;
using ShopMall.FrameWork.Entity;
using ShopMall.FrameWork.IServices;
using ShopMall.FrameWork.IRepository;
namespace ShopMall.FrameWork.Services
{	
	/// <summary>
	/// IBaseRepository
	/// </summary>	
	public class BaseServices<TEntity> : IBaseServices<TEntity> where TEntity : class, new()
    {
		public IBaseRepository<TEntity> baseDal;
       
    }
}

	//----------结束----------
	