
	//----------Shop_sys_user开始----------
    
using System;
namespace ShopMall.FrameWork.Entity
{	
	/// <summary>
	/// Shop_sys_user
	/// </summary>	
	public class Shop_sys_user//可以在这里加上基类等
	{
	//将该表下的字段都遍历出来，可以自定义获取数据描述等信息


	  public int  uid { get; set; }


	  public string  headPortrait { get; set; }


	  public string  loginName { get; set; }


	  public string  passkey { get; set; }


	  public string  passValue { get; set; }


	  public string  nickName { get; set; }


	  public string  realName { get; set; }


	  public int  sex { get; set; }


	  public int  uStatus { get; set; }


	  public string  Mobile { get; set; }


	  public string  Email { get; set; }


	  public int  LoginNum { get; set; }


	  public DateTime  LastLogin { get; set; }


	  public DateTime  creatTime { get; set; }


	  public string  wx_openid { get; set; }


	  public string  qq_code { get; set; }


	  public DateTime  birthday { get; set; }


	  public string  regRemarks { get; set; }
 

    }
}

	//----------Shop_sys_user结束----------
	