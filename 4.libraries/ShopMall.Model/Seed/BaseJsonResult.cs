using ShopMall.Model.ViewModels;
using System;

namespace ShopMall.Model
{
    /// <summary>
    /// 基础类JSON返回序列化类
    /// </summary>
    public class BaseJsonResult
    {
        /// <summary>
        /// 统一的方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        public JsonResult<T> UnifiedFucn<T>(Func<JsonResult<T>> func)
        {
            var model = new JsonResult<T>();
            try
            {
                var RetFunc = func();
                return RetFunc;
            }
            catch (Exception ex)
            {
                model.Result = "读取失败:" + ex.Message;
                model.ret = 3;
                model.Success = false;
            }
            return model;

        }

    }
}
