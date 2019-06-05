
	//----------Shop_orderItem开始----------
    
using System;
namespace ShopMall.FrameWork.Entity
{	
	/// <summary>
	/// Shop_orderItem
	/// </summary>	
	public class Shop_orderItem//可以在这里加上基类等
	{
	//将该表下的字段都遍历出来，可以自定义获取数据描述等信息


	  public int  orderItemID { get; set; }


	  public int  spid { get; set; }


	  public int  skuid { get; set; }


	  public int  orderID { get; set; }


	  public int  number { get; set; }


	  public decimal  price { get; set; }


	  public DateTime  fhDate { get; set; }


	  public string  remake { get; set; }


	  public int  state { get; set; }
 

    }
}

	//----------Shop_orderItem结束----------
	