
	//----------Shop_spfv开始----------
    
using System;
namespace ShopMall.FrameWork.Entity
{	
	/// <summary>
	/// Shop_spfv
	/// </summary>	
	public class Shop_spfv//可以在这里加上基类等
	{
	//将该表下的字段都遍历出来，可以自定义获取数据描述等信息

	  /// <summary>
	  /// 表id
      /// </summary>	
	  public int  spfvID { get; set; }

	  /// <summary>
	  /// 规格值
      /// </summary>	
	  public string  spfValue { get; set; }

	  /// <summary>
	  /// 对应规格表ID
      /// </summary>	
	  public int  spfID { get; set; }

	  /// <summary>
	  /// 排序
      /// </summary>	
	  public int  sort { get; set; }

	  /// <summary>
	  /// 注册时间
      /// </summary>	
	  public DateTime  creatTime { get; set; }
 

    }
}

	//----------Shop_spfv结束----------
	