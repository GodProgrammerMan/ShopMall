	//----------Shop_brand开始----------
    
using System;
namespace ShopMall.FrameWork.Entity
{	
	/// <summary>
	/// Shop_brand
	/// </summary>	
	public class Shop_brand//可以在这里加上基类等
	{
	//将该表下的字段都遍历出来，可以自定义获取数据描述等信息
	  /// <summary>
	  /// 表id
      /// </summary>	
	  public int  id { get; set; }
	  /// <summary>
	  /// 品牌名称
      /// </summary>	
	  public string  bpName { get; set; }
	  /// <summary>
	  /// 排序
      /// </summary>	
	  public int  sort { get; set; }
	  /// <summary>
	  /// 只存一级分类
      /// </summary>	
	  public int  classID { get; set; }
	  /// <summary>
	  /// 注册时间
      /// </summary>	
	  public DateTime  creatTime { get; set; }
	  /// <summary>
	  /// 
      /// </summary>	
	  public bool  isDel { get; set; }
 

    }
}

	//----------Shop_brand结束----------
	