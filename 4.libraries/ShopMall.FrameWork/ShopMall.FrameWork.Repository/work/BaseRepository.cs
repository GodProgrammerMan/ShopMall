
    
	//----------开始----------
	
using System;
using ShopMall.FrameWork.Entity;
using ShopMall.FrameWork.IRepository;
namespace ShopMall.FrameWork.Repository
{	
	/// <summary>
	/// IBaseRepository
	/// </summary>	
	 public  class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, new()
    {

       
    }
}

	//----------结束----------
	