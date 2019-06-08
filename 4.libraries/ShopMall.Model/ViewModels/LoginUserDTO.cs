using System;
using System.Collections.Generic;
using System.Text;

namespace ShopMall.Model.ViewModels
{
    /// <summary>
    /// 登录返回实体
    /// </summary>
    public class LoginUserDTO
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int uid { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string headPortrait { get; set; }
        /// <summary>
        ///手机号
        /// </summary>
        public string mobile { get; set; }
        /// <summary>
        ///昵称
        /// </summary>
        public string nickname { get; set; }
        /// <summary>
        /// 令牌token
        /// </summary>
        public string token { get; set; }
    }
}
