
	//----------Shop_spf开始----------
    
using System;
namespace ShopMall.FrameWork.Entity
{	
	/// <summary>
	/// Shop_spf
	/// </summary>	
	public class Shop_spf//可以在这里加上基类等
	{
	//将该表下的字段都遍历出来，可以自定义获取数据描述等信息


	  public int  spfID { get; set; }


	  public int  classID { get; set; }


	  public string  spfName { get; set; }


	  public int  sort { get; set; }


	  public DateTime  creatTime { get; set; }
 

    }
}

	//----------Shop_spf结束----------
	