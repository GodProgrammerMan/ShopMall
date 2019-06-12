	//----------Shop_orderItem开始----------
    
using System;
namespace ShopMall.FrameWork.Entity
{	
	/// <summary>
	/// Shop_orderItem
	/// </summary>	
	public class Shop_orderItem//可以在这里加上基类等
	{
	//将该表下的字段都遍历出来，可以自定义获取数据描述等信息
	  /// <summary>
	  /// 子订单表
      /// </summary>	
	  public int  orderItemID { get; set; }
	  /// <summary>
	  /// 商品ID
      /// </summary>	
	  public int  spid { get; set; }
	  /// <summary>
	  /// skuID对应sku表
      /// </summary>	
	  public int  skuid { get; set; }
	  /// <summary>
	  /// 订单ID
      /// </summary>	
	  public int  orderID { get; set; }
	  /// <summary>
	  /// 购买数量
      /// </summary>	
	  public int  number { get; set; }
	  /// <summary>
	  /// 价格
      /// </summary>	
	  public decimal  price { get; set; }
	  /// <summary>
	  /// 发货时间
      /// </summary>	
	  public DateTime  fhDate { get; set; }
	  /// <summary>
	  /// 备注
      /// </summary>	
	  public string  remake { get; set; }
	  /// <summary>
	  /// 0-待发货，1-待收货，2-待评价，3-交易成功
      /// </summary>	
	  public int  state { get; set; }
 

    }
}

	//----------Shop_orderItem结束----------
	