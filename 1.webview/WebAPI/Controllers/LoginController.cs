using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopMall.Common;
using ShopMall.Common.Helper;
using ShopMall.IServices;
using ShopMall.Model;
using ShopMall.Model.Models;
using ShopMall.Model.ViewModels;
using WebAPI.Model;

namespace WebAPI.Controllers
{
    /// <summary>
    /// 登录服务接口
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        readonly IShop_sys_userServices _userServices;
        readonly IRedisCacheManager _redisCacheManager;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userServices"></param>
        /// <param name="redisCacheManager"></param>
        public LoginController(IShop_sys_userServices userServices, IRedisCacheManager redisCacheManager)
        {
            _userServices = userServices;
            _redisCacheManager = redisCacheManager;
        }

        /// <summary>
        /// shopmall商城登录接口,无需token
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [Route("loginshop")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<JsonResult<LoginUserDTO>> ShopMallLogin([FromBody] LoginParameterModel obj)
        {
            var model = new JsonResult<LoginUserDTO>
            {
                ret = 0,
                Success = true
            };
            #region 参数检验
            if (string.IsNullOrWhiteSpace(obj.LoginName) || string.IsNullOrWhiteSpace(obj.Password))
            {

            }
            #endregion
            var user = await _userServices.GetSysUserByLoginNameAsync(obj.LoginName);
            return new BaseJsonResult().UnifiedFucn(()=>
            {
                try
                {
                    #region 请求IdentityServer4，校验用户名密码
                    IDictionary<string, string> parameters = new Dictionary<string, string>();
                    parameters.Add("username", "wjk");
                    parameters.Add("password", "123");
                    parameters.Add("grant_type", "password");
                    parameters.Add("client_id", "client2");
                    parameters.Add("client_secret", "secret");
                    var loginMsg = GetNetData.DoPost("http://shopmall.identityserver.com/connect/token", parameters, "UTF-8");
                    #endregion
                    if (loginMsg.IndexOf("error_description") > -1)
                    {
                        var error = JsonHelper.ParseFormByJson<ErrorViewModel>(loginMsg);
                        model.ret = 1;
                        model.Result = error.error_description;
                    }
                    else
                    {
                        var result = JsonHelper.ParseFormByJson<ResultViewModel>(loginMsg);
                        model.ret = 0;
                        model.Result = "登录成功！";
                    }

                }
                catch (Exception e)
                {
                    model.ret = 3;
                    model.Result = "e:" + e;
                }
                return model;
            });
        }
    }
}