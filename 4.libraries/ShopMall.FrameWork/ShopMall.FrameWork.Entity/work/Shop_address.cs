
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


	  public int  id { get; set; }


	  public string  csName { get; set; }


	  public string  csMobilePhone { get; set; }


	  public int  provinceID { get; set; }


	  public int  cityID { get; set; }


	  public int  areaID { get; set; }


	  public string  detail { get; set; }


	  public int  sort { get; set; }


	  public bool  isDefault { get; set; }
 

    }
}

	//----------Shop_address结束----------
	