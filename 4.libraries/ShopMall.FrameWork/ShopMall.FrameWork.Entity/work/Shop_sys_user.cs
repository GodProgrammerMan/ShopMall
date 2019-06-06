
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

	  /// <summary>
	  /// 用户ID，即表ID
      /// </summary>	
	  public int  uid { get; set; }

	  /// <summary>
	  /// 头像
      /// </summary>	
	  public string  headPortrait { get; set; }

	  /// <summary>
	  /// 登录账号（一般为手机号码，或者邮箱账号）
      /// </summary>	
	  public string  loginName { get; set; }

	  /// <summary>
	  /// 密码随机生成的key
      /// </summary>	
	  public string  passkey { get; set; }

	  /// <summary>
	  /// 随机生成的key+密码=passVuale
      /// </summary>	
	  public string  passValue { get; set; }

	  /// <summary>
	  /// 昵称
      /// </summary>	
	  public string  nickName { get; set; }

	  /// <summary>
	  /// 真实姓名
      /// </summary>	
	  public string  realName { get; set; }

	  /// <summary>
	  /// 1-男，2-女
      /// </summary>	
	  public int  sex { get; set; }

	  /// <summary>
	  /// 用户状态（默认为1，激活，0-禁用）
      /// </summary>	
	  public int  uStatus { get; set; }

	  /// <summary>
	  /// 手机号
      /// </summary>	
	  public string  Mobile { get; set; }

	  /// <summary>
	  /// 邮箱
      /// </summary>	
	  public string  Email { get; set; }

	  /// <summary>
	  /// 登录次数
      /// </summary>	
	  public int  LoginNum { get; set; }

	  /// <summary>
	  /// 最近登录时间
      /// </summary>	
	  public DateTime  LastLogin { get; set; }

	  /// <summary>
	  /// 注册时间
      /// </summary>	
	  public DateTime  creatTime { get; set; }

	  /// <summary>
	  /// 微信openid
      /// </summary>	
	  public string  wx_openid { get; set; }

	  /// <summary>
	  /// qq快捷登录
      /// </summary>	
	  public string  qq_code { get; set; }

	  /// <summary>
	  /// 生日
      /// </summary>	
	  public DateTime  birthday { get; set; }

	  /// <summary>
	  /// 注册备注
      /// </summary>	
	  public string  regRemarks { get; set; }
 

    }
}

	//----------Shop_sys_user结束----------
	