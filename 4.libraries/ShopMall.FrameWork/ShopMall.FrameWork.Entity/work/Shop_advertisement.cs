	//----------Shop_advertisement开始----------
    
using System;
namespace ShopMall.FrameWork.Entity
{	
	/// <summary>
	/// Shop_advertisement
	/// </summary>	
	public class Shop_advertisement//可以在这里加上基类等
	{
	//将该表下的字段都遍历出来，可以自定义获取数据描述等信息
	  /// <summary>
	  /// 
      /// </summary>	
	  public int  id { get; set; }
	  /// <summary>
	  /// 
      /// </summary>	
	  public int  spid { get; set; }
	  /// <summary>
	  /// 广告标题
      /// </summary>	
	  public string  advName { get; set; }
	  /// <summary>
	  /// 位置编号（如：移动端mobile_index_位置，pc端PC_index_位置）
      /// </summary>	
	  public string  positionNo { get; set; }
	  /// <summary>
	  /// 到期时间
      /// </summary>	
	  public DateTime  expirationDate { get; set; }
	  /// <summary>
	  /// 注册时间
      /// </summary>	
	  public DateTime  creatTime { get; set; }
	  /// <summary>
	  /// 排序
      /// </summary>	
	  public int  sort { get; set; }
	  /// <summary>
	  /// 价格
      /// </summary>	
	  public decimal  price { get; set; }
 

    }
}

	//----------Shop_advertisement结束----------
	