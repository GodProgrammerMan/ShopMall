
	//----------Shop_spu_evaluate开始----------
    
using System;
namespace ShopMall.FrameWork.Entity
{	
	/// <summary>
	/// Shop_spu_evaluate
	/// </summary>	
	public class Shop_spu_evaluate//可以在这里加上基类等
	{
	//将该表下的字段都遍历出来，可以自定义获取数据描述等信息


	  public int  id { get; set; }


	  public int  spid { get; set; }


	  public int  skuid { get; set; }


	  public int  spStar { get; set; }


	  public string  spevaluate { get; set; }


	  public int  shopWl { get; set; }


	  public bool  anonymous { get; set; }


	  public int  shopFw { get; set; }


	  public DateTime  creatTime { get; set; }
 

    }
}

	//----------Shop_spu_evaluate结束----------
	