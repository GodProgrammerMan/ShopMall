
	//----------Shop_brand开始----------
    
using System;
namespace ShopMall.FrameWork.Entity
{	
	/// <summary>
	/// Shop_brand
	/// </summary>	
	public class Shop_brand//可以在这里加上基类等
	{
	//将该表下的字段都遍历出来，可以自定义获取数据描述等信息


	  public int  id { get; set; }


	  public string  bpName { get; set; }


	  public int  sort { get; set; }


	  public int  classID { get; set; }


	  public DateTime  creatTime { get; set; }


	  public bool  isDel { get; set; }
 

    }
}

	//----------Shop_brand结束----------
	