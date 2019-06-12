	//----------province_city_county开始----------
    
using System;
namespace ShopMall.FrameWork.Entity
{	
	/// <summary>
	/// province_city_county
	/// </summary>	
	public class province_city_county//可以在这里加上基类等
	{
	//将该表下的字段都遍历出来，可以自定义获取数据描述等信息
	  /// <summary>
	  /// 表id
      /// </summary>	
	  public int  id { get; set; }
	  /// <summary>
	  /// 名称
      /// </summary>	
	  public string  name { get; set; }
	  /// <summary>
	  /// 父级ID
      /// </summary>	
	  public int  pid { get; set; }
	  /// <summary>
	  /// 1表示省，2表示市，3表示县
      /// </summary>	
	  public int  ptype { get; set; }
	  /// <summary>
	  /// 编码
      /// </summary>	
	  public string  code { get; set; }
	  /// <summary>
	  /// 状态，默认为1
      /// </summary>	
	  public int  status { get; set; }
	  /// <summary>
	  /// 创建日期
      /// </summary>	
	  public int  createTime { get; set; }
	  /// <summary>
	  /// 更改日期
      /// </summary>	
	  public int  updateTime { get; set; }
 

    }
}

	//----------province_city_county结束----------
	