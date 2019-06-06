
	//----------Shop_advertisement_img开始----------
    
using System;
namespace ShopMall.FrameWork.Entity
{	
	/// <summary>
	/// Shop_advertisement_img
	/// </summary>	
	public class Shop_advertisement_img//可以在这里加上基类等
	{
	//将该表下的字段都遍历出来，可以自定义获取数据描述等信息

	  /// <summary>
	  /// 
      /// </summary>	
	  public int  id { get; set; }

	  /// <summary>
	  /// 广告ID
      /// </summary>	
	  public int  advID { get; set; }

	  /// <summary>
	  /// 图片路径
      /// </summary>	
	  public string  imgUrl { get; set; }

	  /// <summary>
	  /// 排序
      /// </summary>	
	  public int  sort { get; set; }
 

    }
}

	//----------Shop_advertisement_img结束----------
	