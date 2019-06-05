
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


	  public int  id { get; set; }


	  public string  name { get; set; }


	  public int  pid { get; set; }


	  public int  ptype { get; set; }


	  public string  code { get; set; }


	  public int  status { get; set; }


	  public int  createTime { get; set; }


	  public int  updateTime { get; set; }
 

    }
}

	//----------province_city_county结束----------
	