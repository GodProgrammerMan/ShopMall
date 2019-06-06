
	//----------Shop_spf开始----------
    
using System;
namespace ShopMall.Model.Models
{	
	/// <summary>
	/// Shop_spf
	/// </summary>	
	public class Shop_spf//可以在这里加上基类等
	{
	//将该表下的字段都遍历出来，可以自定义获取数据描述等信息

	  /// <summary>
	  /// 表id
      /// </summary>	
	  public int  spfID { get; set; }

	  /// <summary>
	  /// 分类ID
      /// </summary>	
	  public int  classID { get; set; }

	  /// <summary>
	  /// 规格名称
      /// </summary>	
	  public string  spfName { get; set; }

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

	//----------Shop_spf结束----------
	