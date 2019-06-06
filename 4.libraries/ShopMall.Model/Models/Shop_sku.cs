
	//----------Shop_sku开始----------
    
using System;
namespace ShopMall.Model.Models
{	
	/// <summary>
	/// Shop_sku
	/// </summary>	
	public class Shop_sku//可以在这里加上基类等
	{
	//将该表下的字段都遍历出来，可以自定义获取数据描述等信息

	  /// <summary>
	  /// 表id
      /// </summary>	
	  public int  skuID { get; set; }

	  /// <summary>
	  /// 商品ID
      /// </summary>	
	  public int  spid { get; set; }

	  /// <summary>
	  /// 规格值，ids
      /// </summary>	
	  public string  spfvIDs { get; set; }

	  /// <summary>
	  /// 对应属性值字符串
      /// </summary>	
	  public string  spfvStr { get; set; }

	  /// <summary>
	  /// 
      /// </summary>	
	  public string  skuImg { get; set; }

	  /// <summary>
	  /// 价格
      /// </summary>	
	  public decimal  price { get; set; }

	  /// <summary>
	  /// 库存
      /// </summary>	
	  public int  stock { get; set; }

	  /// <summary>
	  /// sku状态，（1正常，0下架）
      /// </summary>	
	  public int  skuState { get; set; }

	  /// <summary>
	  /// 注册时间
      /// </summary>	
	  public DateTime  creatTime { get; set; }
 

    }
}

	//----------Shop_sku结束----------
	