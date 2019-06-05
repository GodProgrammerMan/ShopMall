
	//----------Shop_refund开始----------
    
using System;
namespace ShopMall.FrameWork.Entity
{	
	/// <summary>
	/// Shop_refund
	/// </summary>	
	public class Shop_refund//可以在这里加上基类等
	{
	//将该表下的字段都遍历出来，可以自定义获取数据描述等信息


	  public int  id { get; set; }


	  public string  uid { get; set; }


	  public string  refundNo { get; set; }


	  public string  orderNo { get; set; }


	  public int  state { get; set; }


	  public string  refundMsg { get; set; }


	  public DateTime  creatTime { get; set; }
 

    }
}

	//----------Shop_refund结束----------
	