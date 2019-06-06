
	//----------Shop_collection开始----------
    
using System;
namespace ShopMall.Model.Models
{	
	/// <summary>
	/// Shop_collection
	/// </summary>	
	public class Shop_collection//可以在这里加上基类等
	{
	//将该表下的字段都遍历出来，可以自定义获取数据描述等信息

	  /// <summary>
	  /// 
      /// </summary>	
	  public int  id { get; set; }

	  /// <summary>
	  /// 商品id
      /// </summary>	
	  public int  spid { get; set; }

	  /// <summary>
	  /// 
      /// </summary>	
	  public int  uid { get; set; }

	  /// <summary>
	  /// 注册时间
      /// </summary>	
	  public DateTime  creatTime { get; set; }
 

    }
}

	//----------Shop_collection结束----------
	