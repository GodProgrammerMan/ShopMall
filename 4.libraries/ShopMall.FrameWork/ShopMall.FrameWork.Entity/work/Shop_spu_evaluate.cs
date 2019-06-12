	//----------Shop_spu_evaluate开始----------
    
using System;
namespace ShopMall.FrameWork.Entity
{	
	/// <summary>
	/// Shop_spu_evaluate
	/// </summary>	
	public class Shop_spu_evaluate//可以在这里加上基类等
	{
	//将该表下的字段都遍历出来，可以自定义获取数据描述等信息
	  /// <summary>
	  /// 表id
      /// </summary>	
	  public int  id { get; set; }
	  /// <summary>
	  /// 
      /// </summary>	
	  public int  spid { get; set; }
	  /// <summary>
	  /// 
      /// </summary>	
	  public int  skuid { get; set; }
	  /// <summary>
	  /// 商品星级
      /// </summary>	
	  public int  spStar { get; set; }
	  /// <summary>
	  /// 商品评价
      /// </summary>	
	  public string  spevaluate { get; set; }
	  /// <summary>
	  /// 物流星级评价
      /// </summary>	
	  public int  shopWl { get; set; }
	  /// <summary>
	  /// 是否匿名
      /// </summary>	
	  public bool  anonymous { get; set; }
	  /// <summary>
	  /// 商品服务星级评价
      /// </summary>	
	  public int  shopFw { get; set; }
	  /// <summary>
	  /// 注册时间
      /// </summary>	
	  public DateTime  creatTime { get; set; }
 

    }
}

	//----------Shop_spu_evaluate结束----------
	