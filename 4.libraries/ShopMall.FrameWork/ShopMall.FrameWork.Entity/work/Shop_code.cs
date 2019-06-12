	//----------Shop_code开始----------
    
using System;
namespace ShopMall.FrameWork.Entity
{	
	/// <summary>
	/// Shop_code
	/// </summary>	
	public class Shop_code//可以在这里加上基类等
	{
	//将该表下的字段都遍历出来，可以自定义获取数据描述等信息
	  /// <summary>
	  /// 
      /// </summary>	
	  public int  id { get; set; }
	  /// <summary>
	  /// 验证码类型（1-邮箱验证，2-手机验证）
      /// </summary>	
	  public int  codeType { get; set; }
	  /// <summary>
	  /// 验证码
      /// </summary>	
	  public string  code { get; set; }
	  /// <summary>
	  /// 发送内容
      /// </summary>	
	  public string  sendContent { get; set; }
	  /// <summary>
	  /// 账号
      /// </summary>	
	  public string  toName { get; set; }
	  /// <summary>
	  /// uid(如未登录则为0)
      /// </summary>	
	  public int  uid { get; set; }
	  /// <summary>
	  /// 创建时间
      /// </summary>	
	  public DateTime  creatTime { get; set; }
	  /// <summary>
	  /// 有效时间（当前时间与创建时间相加值）
      /// </summary>	
	  public int  effectMinutes { get; set; }
	  /// <summary>
	  /// 状态，1-已使用0-未使用
      /// </summary>	
	  public int  state { get; set; }
 

    }
}

	//----------Shop_code结束----------
	