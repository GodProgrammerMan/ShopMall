	//----------Shop_spu开始----------
    
using System;
namespace ShopMall.FrameWork.Entity
{	
	/// <summary>
	/// Shop_spu
	/// </summary>	
	public class Shop_spu//可以在这里加上基类等
	{
	//将该表下的字段都遍历出来，可以自定义获取数据描述等信息
	  /// <summary>
	  /// 商品ID
      /// </summary>	
	  public int  spid { get; set; }
	  /// <summary>
	  /// 商品名称
      /// </summary>	
	  public string  spName { get; set; }
	  /// <summary>
	  /// 轨迹，对应所在分类的轨迹
      /// </summary>	
	  public string  classIDs { get; set; }
	  /// <summary>
	  /// 商品分类id，
      /// </summary>	
	  public int  ClassID { get; set; }
	  /// <summary>
	  /// 品牌ID
      /// </summary>	
	  public int  bpid { get; set; }
	  /// <summary>
	  /// 平均价格
      /// </summary>	
	  public decimal  vagPrice { get; set; }
	  /// <summary>
	  /// 店铺ID
      /// </summary>	
	  public int  shopid { get; set; }
	  /// <summary>
	  /// 封面
      /// </summary>	
	  public string  cover { get; set; }
	  /// <summary>
	  /// 排序
      /// </summary>	
	  public int  sort { get; set; }
	  /// <summary>
	  /// 注册时间
      /// </summary>	
	  public DateTime  creatTime { get; set; }
	  /// <summary>
	  /// 状态（1正常，0下架）
      /// </summary>	
	  public int  saleState { get; set; }
	  /// <summary>
	  /// 销量
      /// </summary>	
	  public int  salesNumber { get; set; }
	  /// <summary>
	  /// 浏览量
      /// </summary>	
	  public int  views { get; set; }
 

    }
}

	//----------Shop_spu结束----------
	