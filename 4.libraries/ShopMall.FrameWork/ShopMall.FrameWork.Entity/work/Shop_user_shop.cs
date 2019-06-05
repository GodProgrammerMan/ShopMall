
	//----------Shop_user_shop开始----------
    
using System;
namespace ShopMall.FrameWork.Entity
{	
	/// <summary>
	/// Shop_user_shop
	/// </summary>	
	public class Shop_user_shop//可以在这里加上基类等
	{
	//将该表下的字段都遍历出来，可以自定义获取数据描述等信息


	  public int  shopid { get; set; }


	  public string  shopName { get; set; }


	  public int  uid { get; set; }


	  public string  shopTelephone { get; set; }


	  public int  shopState { get; set; }


	  public int  sort { get; set; }


	  public DateTime  creatTime { get; set; }


	  public string  shopLogo { get; set; }


	  public string  remarks { get; set; }
 

    }
}

	//----------Shop_user_shop结束----------
	