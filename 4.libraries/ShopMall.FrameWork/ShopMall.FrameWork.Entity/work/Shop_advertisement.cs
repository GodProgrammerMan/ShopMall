
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


	  public int  id { get; set; }


	  public int  spid { get; set; }


	  public string  positionNo { get; set; }


	  public DateTime  expirationDate { get; set; }


	  public DateTime  creatTime { get; set; }


	  public int  sort { get; set; }


	  public decimal  price { get; set; }
 

    }
}

	//----------Shop_advertisement结束----------
	