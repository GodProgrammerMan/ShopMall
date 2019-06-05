
	//----------Shop_sp_class开始----------
    
using System;
namespace ShopMall.FrameWork.Entity
{	
	/// <summary>
	/// Shop_sp_class
	/// </summary>	
	public class Shop_sp_class//可以在这里加上基类等
	{
	//将该表下的字段都遍历出来，可以自定义获取数据描述等信息


	  public int  id { get; set; }


	  public int  className { get; set; }


	  public string  idList { get; set; }


	  public int  fid { get; set; }


	  public int  sort { get; set; }


	  public bool  IsDelete { get; set; }


	  public DateTime  creatTime { get; set; }
 

    }
}

	//----------Shop_sp_class结束----------
	