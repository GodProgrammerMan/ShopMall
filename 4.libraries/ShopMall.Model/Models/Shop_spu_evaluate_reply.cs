
	//----------Shop_spu_evaluate_reply开始----------
    
using System;
namespace ShopMall.Model.Models
{	
	/// <summary>
	/// Shop_spu_evaluate_reply
	/// </summary>	
	public class Shop_spu_evaluate_reply//可以在这里加上基类等
	{
	//将该表下的字段都遍历出来，可以自定义获取数据描述等信息

	  /// <summary>
	  /// 
      /// </summary>	
	  public int  id { get; set; }

	  /// <summary>
	  /// 评价ID
      /// </summary>	
	  public int  evaluateID { get; set; }

	  /// <summary>
	  /// 回复img
      /// </summary>	
	  public string  econtent { get; set; }

	  /// <summary>
	  /// 回复人uid
      /// </summary>	
	  public int  replyuid { get; set; }

	  /// <summary>
	  /// 被回复人
      /// </summary>	
	  public int  coveruid { get; set; }

	  /// <summary>
	  /// 注册时间
      /// </summary>	
	  public DateTime  creatTime { get; set; }
 

    }
}

	//----------Shop_spu_evaluate_reply结束----------
	