	//----------Shop_address开始----------
    
using System;
namespace ShopMall.FrameWork.Entity
{	
	/// <summary>
	/// Shop_address
	/// </summary>	
	public class Shop_address//可以在这里加上基类等
	{
	//将该表下的字段都遍历出来，可以自定义获取数据描述等信息
	  /// <summary>
	  /// 
      /// </summary>	
	  public int  id { get; set; }
	  /// <summary>
	  /// 收货人
      /// </summary>	
	  public string  csName { get; set; }
	  /// <summary>
	  /// 收货人
      /// </summary>	
	  public string  csMobilePhone { get; set; }
	  /// <summary>
	  /// 
      /// </summary>	
	  public int  provinceID { get; set; }
	  /// <summary>
	  /// 
      /// </summary>	
	  public int  cityID { get; set; }
	  /// <summary>
	  /// 区县ID
      /// </summary>	
	  public int  areaID { get; set; }
	  /// <summary>
	  /// 详细街道
      /// </summary>	
	  public string  detail { get; set; }
	  /// <summary>
	  /// 排序
      /// </summary>	
	  public int  sort { get; set; }
	  /// <summary>
	  /// 是否为默认
      /// </summary>	
	  public bool  isDefault { get; set; }
 

    }
}

	//----------Shop_address结束----------
	