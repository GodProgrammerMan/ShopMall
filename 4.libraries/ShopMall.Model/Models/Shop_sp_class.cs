
	//----------Shop_sp_class开始----------
    
using System;
namespace ShopMall.Model.Models
{	
	/// <summary>
	/// Shop_sp_class
	/// </summary>	
	public class Shop_sp_class//可以在这里加上基类等
	{
	//将该表下的字段都遍历出来，可以自定义获取数据描述等信息

	  /// <summary>
	  /// 表ID
      /// </summary>	
	  public int  id { get; set; }

	  /// <summary>
	  /// 分类名称
      /// </summary>	
	  public int  className { get; set; }

	  /// <summary>
	  /// 轨迹，包括父级id
      /// </summary>	
	  public string  idList { get; set; }

	  /// <summary>
	  /// 父级分类
      /// </summary>	
	  public int  fid { get; set; }

	  /// <summary>
	  /// 排序
      /// </summary>	
	  public int  sort { get; set; }

	  /// <summary>
	  /// 是否删除
      /// </summary>	
	  public bool  IsDelete { get; set; }

	  /// <summary>
	  /// 注册时间
      /// </summary>	
	  public DateTime  creatTime { get; set; }
 

    }
}

	//----------Shop_sp_class结束----------
	