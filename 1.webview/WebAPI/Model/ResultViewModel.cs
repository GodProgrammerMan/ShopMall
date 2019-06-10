using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model
{
    /// <summary>
    /// 返回实体
    /// </summary>
    public class ResultViewModel
    {
        /// <summary>
        /// 返回token
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// 返回token类型
        /// </summary>
        public string TokenType { get; set; }
        /// <summary>
        /// 有效时间
        /// </summary>
        public string TokenTime { get; set; }
    }
}
