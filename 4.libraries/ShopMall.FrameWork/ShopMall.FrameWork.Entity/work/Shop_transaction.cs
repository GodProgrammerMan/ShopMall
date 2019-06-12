	//----------Shop_transaction开始----------
    
using System;
namespace ShopMall.FrameWork.Entity
{	
	/// <summary>
	/// Shop_transaction
	/// </summary>	
	public class Shop_transaction//可以在这里加上基类等
	{
	//将该表下的字段都遍历出来，可以自定义获取数据描述等信息
	  /// <summary>
	  /// 表ID
      /// </summary>	
	  public int  id { get; set; }
	  /// <summary>
	  /// 流水号
      /// </summary>	
	  public string  transactionNo { get; set; }
	  /// <summary>
	  /// 订单号对应交易号
      /// </summary>	
	  public string  orderNo { get; set; }
	  /// <summary>
	  /// 第三方订单号
      /// </summary>	
	  public string  thirdOrderNo { get; set; }
	  /// <summary>
	  /// 付款方账号
      /// </summary>	
	  public string  payAccount { get; set; }
	  /// <summary>
	  /// 收入方账号
      /// </summary>	
	  public string  incomeAccount { get; set; }
	  /// <summary>
	  /// 类型（1-支付宝，2-微信，3-银行）
      /// </summary>	
	  public int  payType { get; set; }
	  /// <summary>
	  /// 流水信息
      /// </summary>	
	  public string  transactionMsg { get; set; }
	  /// <summary>
	  /// 流水类型（1-支出，2-收入）
      /// </summary>	
	  public int  transactionType { get; set; }
	  /// <summary>
	  /// 用户ID
      /// </summary>	
	  public int  uid { get; set; }
	  /// <summary>
	  /// 注册时间
      /// </summary>	
	  public DateTime  creatTime { get; set; }
 

    }
}

	//----------Shop_transaction结束----------
	