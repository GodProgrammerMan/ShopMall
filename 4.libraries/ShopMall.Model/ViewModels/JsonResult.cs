using System;
using System.Collections.Generic;
using System.Text;

namespace ShopMall.Model.ViewModels
{
    /// <summary>
    /// API返回信息
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class JsonResult<T>
    {
        private bool _Success = true;
        /// <summary>
        /// 返回成功
        /// </summary>
        public bool Success
        {
            get { return _Success; }
            set { _Success = value; }
        }
        /// <summary>
        /// 0正常返回  1参数错误   2鉴权失败   3内部错误  4其它错误  5没有记录  6分页数据没有记录了
        /// </summary>
        public int ret { get; set; }
        /// <summary>
        ///  返回消息
        /// </summary>
        public string Result { get; set; }
        /// <summary>
        /// 内容包
        /// </summary>
        public T Content { get; set; }

        /// <summary>
        /// JSONResult
        /// </summary>
        public JsonResult()
        {

        }
        /// <summary>
        /// JSONResult
        /// </summary>
        /// <param name="Success">成功失败?</param>
        /// <param name="ret">0正常返回  1参数错误   2鉴权失败   3内部错误  4其它错误  5没有记录  6分页数据没有记录了</param>
        /// <param name="Result">返回结果描述</param>
        public JsonResult(bool Success, int ret, string Result)
        {
            this.Success = Success;
            this.ret = ret;
            this.Result = Result;
        }
    }
}
