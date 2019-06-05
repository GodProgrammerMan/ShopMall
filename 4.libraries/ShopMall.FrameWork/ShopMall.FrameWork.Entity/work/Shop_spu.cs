
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


	  public int  spid { get; set; }


	  public string  spName { get; set; }


	  public string  classIDs { get; set; }


	  public int  ClassID { get; set; }


	  public int  bpid { get; set; }


	  public decimal  vagPrice { get; set; }


	  public int  shopid { get; set; }


	  public string  cover { get; set; }


	  public int  sort { get; set; }


	  public DateTime  creatTime { get; set; }


	  public int  saleState { get; set; }


	  public int  salesNumber { get; set; }


	  public int  views { get; set; }
 

    }
}

	//----------Shop_spu结束----------
	