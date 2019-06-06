
	//----------Shop_order开始----------
    
using System;
namespace ShopMall.Model.Models
{	
	/// <summary>
	/// Shop_order
	/// </summary>	
	public class Shop_order//可以在这里加上基类等
	{
	//将该表下的字段都遍历出来，可以自定义获取数据描述等信息

	  /// <summary>
	  /// 订单ID
      /// </summary>	
	  public int  orderID { get; set; }

	  /// <summary>
	  /// 订单号
      /// </summary>	
	  public string  orderNo { get; set; }

	  /// <summary>
	  /// 第三方订单号
      /// </summary>	
	  public string  thirdOrderNo { get; set; }

	  /// <summary>
	  /// 手机
      /// </summary>	
	  public string  mobilePhone { get; set; }

	  /// <summary>
	  /// 地址ID
      /// </summary>	
	  public int  addressID { get; set; }

	  /// <summary>
	  /// 用户ID
      /// </summary>	
	  public int  uid { get; set; }

	  /// <summary>
	  /// 订单总金额
      /// </summary>	
	  public decimal  totalPrice { get; set; }

	  /// <summary>
	  /// 
      /// </summary>	
	  public string  remarks { get; set; }

	  /// <summary>
	  /// 过期时间
      /// </summary>	
	  public DateTime  expirationDate { get; set; }

	  /// <summary>
	  /// 注册时间
      /// </summary>	
	  public DateTime  creatTime { get; set; }

	  /// <summary>
	  /// 订单状态（0-订单已关闭，1-可用）
      /// </summary>	
	  public int  OrderStatus { get; set; }

	  /// <summary>
	  /// 是否支付
      /// </summary>	
	  public bool  PayStatus { get; set; }

	  /// <summary>
	  /// 类型（1-支付宝，2-微信，3-银行）
      /// </summary>	
	  public int  payType { get; set; }
 

    }
}

	//----------Shop_order结束----------
	