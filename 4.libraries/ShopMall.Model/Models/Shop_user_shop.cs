
	//----------Shop_user_shop开始----------
    
using System;
namespace ShopMall.Model.Models
{	
	/// <summary>
	/// Shop_user_shop
	/// </summary>	
	public class Shop_user_shop//可以在这里加上基类等
	{
	//将该表下的字段都遍历出来，可以自定义获取数据描述等信息

	  /// <summary>
	  /// 店铺ID
      /// </summary>	
	  public int  shopid { get; set; }

	  /// <summary>
	  /// 店铺名称
      /// </summary>	
	  public string  shopName { get; set; }

	  /// <summary>
	  /// 用户表id
      /// </summary>	
	  public int  uid { get; set; }

	  /// <summary>
	  /// 
      /// </summary>	
	  public string  shopTelephone { get; set; }

	  /// <summary>
	  /// 店铺状态（1正常，0-下架）
      /// </summary>	
	  public int  shopState { get; set; }

	  /// <summary>
	  /// 排序
      /// </summary>	
	  public int  sort { get; set; }

	  /// <summary>
	  /// 注册时间
      /// </summary>	
	  public DateTime  creatTime { get; set; }

	  /// <summary>
	  /// 店铺logo
      /// </summary>	
	  public string  shopLogo { get; set; }

	  /// <summary>
	  /// 备注
      /// </summary>	
	  public string  remarks { get; set; }
 

    }
}

	//----------Shop_user_shop结束----------
	