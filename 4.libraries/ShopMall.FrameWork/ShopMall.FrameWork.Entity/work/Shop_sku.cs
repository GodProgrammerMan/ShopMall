
	//----------Shop_sku开始----------
    
using System;
namespace ShopMall.FrameWork.Entity
{	
	/// <summary>
	/// Shop_sku
	/// </summary>	
	public class Shop_sku//可以在这里加上基类等
	{
	//将该表下的字段都遍历出来，可以自定义获取数据描述等信息


	  public int  skuID { get; set; }


	  public int  spid { get; set; }


	  public string  spfvIDs { get; set; }


	  public string  spfvStr { get; set; }


	  public string  skuImg { get; set; }


	  public decimal  price { get; set; }


	  public int  stock { get; set; }


	  public int  skuState { get; set; }


	  public DateTime  creatTime { get; set; }
 

    }
}

	//----------Shop_sku结束----------
	