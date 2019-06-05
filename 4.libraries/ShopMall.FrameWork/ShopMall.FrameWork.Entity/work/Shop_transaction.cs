
	//----------Shop_transaction开始----------
    
using System;
namespace ShopMall.FrameWork.Entity
{	
	/// <summary>
	/// Shop_transaction
	/// </summary>	
	public class Shop_transaction//可以在这里加上基类等
	{
	//将该表下的字段都遍历出来，可以自定义获取数据描述等信息


	  public int  id { get; set; }


	  public string  transactionNo { get; set; }


	  public string  orderNo { get; set; }


	  public string  thirdOrderNo { get; set; }


	  public string  payAccount { get; set; }


	  public string  incomeAccount { get; set; }


	  public int  payType { get; set; }


	  public string  transactionMsg { get; set; }


	  public int  transactionType { get; set; }


	  public int  uid { get; set; }


	  public DateTime  creatTime { get; set; }
 

    }
}

	//----------Shop_transaction结束----------
	