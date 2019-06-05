
	//----------Shop_order开始----------
    
using System;
namespace ShopMall.FrameWork.Entity
{	
	/// <summary>
	/// Shop_order
	/// </summary>	
	public class Shop_order//可以在这里加上基类等
	{
	//将该表下的字段都遍历出来，可以自定义获取数据描述等信息


	  public int  orderID { get; set; }


	  public string  orderNo { get; set; }


	  public string  thirdOrderNo { get; set; }


	  public string  mobilePhone { get; set; }


	  public int  addressID { get; set; }


	  public int  uid { get; set; }


	  public decimal  totalPrice { get; set; }


	  public string  remarks { get; set; }


	  public DateTime  expirationDate { get; set; }


	  public DateTime  creatTime { get; set; }


	  public int  OrderStatus { get; set; }


	  public bool  PayStatus { get; set; }


	  public int  payType { get; set; }
 

    }
}

	//----------Shop_order结束----------
	