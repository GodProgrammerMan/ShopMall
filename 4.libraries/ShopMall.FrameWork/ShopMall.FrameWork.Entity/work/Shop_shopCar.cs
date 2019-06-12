	//----------Shop_shopCar开始----------
    
using System;
namespace ShopMall.FrameWork.Entity
{	
	/// <summary>
	/// Shop_shopCar
	/// </summary>	
	public class Shop_shopCar//可以在这里加上基类等
	{
	//将该表下的字段都遍历出来，可以自定义获取数据描述等信息
	  /// <summary>
	  /// 购物车表id
      /// </summary>	
	  public int  id { get; set; }
	  /// <summary>
	  /// 用户id
      /// </summary>	
	  public int  uid { get; set; }
	  /// <summary>
	  /// 对应表skuid
      /// </summary>	
	  public int  skuid { get; set; }
	  /// <summary>
	  /// 数量
      /// </summary>	
	  public int  Number { get; set; }
	  /// <summary>
	  /// 价格
      /// </summary>	
	  public decimal  Price { get; set; }
	  /// <summary>
	  /// 注册时间
      /// </summary>	
	  public DateTime  creatTime { get; set; }
 

    }
}

	//----------Shop_shopCar结束----------
	