using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model
{
    /// <summary>
    /// 登录参数
    /// </summary>
    public class LoginParameterModel
    {
        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 来源
        /// </summary>
        public string Source { get; set; }
    }
    /// <summary>
    /// 注册
    /// </summary>
    public class RegisterParameterModel {
        /// <summary>
        /// 注册、一般是邮箱、手机号码
        /// </summary>
        public string loginName { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string mobilePhone { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string passWord { get; set; }
        /// <summary>
        /// 重复密码
        /// </summary>
        public string repass { get; set; }
        /// <summary>
        /// 来源
        /// </summary>
        public string source { get; set; }
        /// <summary>
        /// 邮箱验证码
        /// </summary>
        public string code { get; set; }
    }
    /// <summary>
    /// 单个实体
    /// </summary>
    public class StrParameterModel{
        /// <summary>
        /// 字符
        /// </summary>
        public string keyStr { get; set; }
    }
}
