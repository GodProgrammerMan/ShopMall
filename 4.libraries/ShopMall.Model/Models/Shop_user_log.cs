
using System;
namespace ShopMall.Model.Models
{	
	/// <summary>
	/// Shop_user_log
	/// </summary>	
	public class Shop_user_log//可以在这里加上基类等
	{
	//将该表下的字段都遍历出来，可以自定义获取数据描述等信息

	  /// <summary>
	  /// 表ID
      /// </summary>	
	  public int  id { get; set; }

	  /// <summary>
	  /// 记录类型(1-登录，2-注册)
      /// </summary>	
	  public int  logType { get; set; }

	  /// <summary>
	  /// 创建时间
      /// </summary>	
	  public DateTime  CreateTime { get; set; }

	  /// <summary>
	  /// 描述
      /// </summary>	
	  public string  bcontent { get; set; }

	  /// <summary>
	  /// 来源
      /// </summary>	
	  public string  source { get; set; }

	  /// <summary>
	  /// 用户ID
      /// </summary>	
	  public int  uid { get; set; }
 

    }
}

	//----------Shop_user_log结束----------
	