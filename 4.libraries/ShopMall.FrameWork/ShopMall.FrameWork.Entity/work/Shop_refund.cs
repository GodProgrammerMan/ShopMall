	//----------Shop_refund开始----------
    
using System;
namespace ShopMall.FrameWork.Entity
{	
	/// <summary>
	/// Shop_refund
	/// </summary>	
	public class Shop_refund//可以在这里加上基类等
	{
	//将该表下的字段都遍历出来，可以自定义获取数据描述等信息
	  /// <summary>
	  /// 
      /// </summary>	
	  public int  id { get; set; }
	  /// <summary>
	  /// 
      /// </summary>	
	  public string  uid { get; set; }
	  /// <summary>
	  /// 退款编号
      /// </summary>	
	  public string  refundNo { get; set; }
	  /// <summary>
	  /// 订单号
      /// </summary>	
	  public string  orderNo { get; set; }
	  /// <summary>
	  /// 状态（0-正在申请，1申请通过，2申请不通过）
      /// </summary>	
	  public int  state { get; set; }
	  /// <summary>
	  /// 退款理由
      /// </summary>	
	  public string  refundMsg { get; set; }
	  /// <summary>
	  /// 注册时间
      /// </summary>	
	  public DateTime  creatTime { get; set; }
 

    }
}

	//----------Shop_refund结束----------
	