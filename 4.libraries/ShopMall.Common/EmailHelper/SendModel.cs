using System;
using System.Collections.Generic;
using System.Text;

namespace ShopMall.Common.EmailHelper
{
    public class SendModel
    {
        /// <summary>
        /// 发送人
        /// </summary>
        public string FromEmali{ get; set; }
        /// <summary>
        /// 发送
        /// </summary>
        public string FromName { get; set; }
        /// <summary>
        /// 收件人
        /// </summary>
        public string ToEmali { get; set; }
        /// <summary>
        /// 发送
        /// </summary>
        public string ToName { get; set; }
        /// <summary>
        /// 发送内容
        /// </summary>
        public string MsgContent { get; set; }
        /// <summary>
        /// 信息类型(1、单纯的纯文本。2、html文本)
        /// </summary>
        public int MsgType { get; set; }
        /// <summary>
        /// 主题
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// 发送人的账号
        /// </summary>
        public string FromLoginName{ get; set; }
        /// <summary>
        /// 发送人账号密码
        /// </summary>
        public string FromLoginPass { get; set; }
    }
}
