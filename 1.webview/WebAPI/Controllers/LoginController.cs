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
        readonly IShop_user_logServices _User_LogServices;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userServices"></param>
        /// <param name="redisCacheManager"></param>
        /// <param name="user_LogServices"></param>
        public LoginController(IShop_sys_userServices userServices, IRedisCacheManager redisCacheManager, IShop_user_logServices user_LogServices)
        {
            _userServices = userServices;
            _redisCacheManager = redisCacheManager;
            _User_LogServices = user_LogServices;
        }

        #region 登录ShopMall
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
                model.ret = 1;
                model.Result = "参数有误！";
                return model;
            }
            #endregion
            var user = await _userServices.GetSysUserByLoginNameAsync(obj.LoginName.Trim());
            if (user == null)
            {
                model.ret = 1;
                model.Result = "不存在该用户！";
                return model;
            }
            return new BaseJsonResult().UnifiedFucn(()=>
            {
                try
                {
                    #region 请求IdentityServer4，校验用户名密码
                    IDictionary<string, string> parameters = new Dictionary<string, string>();
                    parameters.Add("username", obj.LoginName.Trim());
                    parameters.Add("password", obj.Password.Trim());
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
                        LoginUserDTO loginUserDTO = new LoginUserDTO() {
                            headPortrait = string.IsNullOrEmpty(user.headPortrait) ? "默认头像" : user.headPortrait,
                            mobile = user.Mobile,
                            nickname = user.nickName,
                            token = $"{result.TokenType} {result.Token}",
                            uid = user.uid
                        };
                        _User_LogServices.LoginSuccessServiceAsync(user.uid, 1, $"{user.loginName}登录系统", obj.Source);
                        model.Result = "登录成功！";
                        model.Content = loginUserDTO;
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
        #endregion

        #region 注册ShopMall
        /// <summary>
        /// 注册ShopMall
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [Route("loginshop")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<JsonResult<bool>> RegisterShopMall([FromBody] RegisterParameterModel obj) {
            var result = new JsonResult<bool>() {
                ret = 0,
                Success = true
            };
            #region 参数校验
            if (string.IsNullOrWhiteSpace(obj.loginName) || string.IsNullOrWhiteSpace(obj.mobilePhone) || string.IsNullOrWhiteSpace(obj.passWord) || string.IsNullOrWhiteSpace(obj.repass)) {
                result.ret = 1;
                result.Result = "请填写完整信息！";
                result.Content = false;
                return result;
            }
            if (obj.loginName.Length >= 20) {
                result.ret = 1;
                result.Result = "用户名太长！";
                result.Content = false;
                return result;
            }
            if (!obj.passWord.Equals(obj.repass) && obj.repass.Length >= 20)
            {
                result.ret = 1;
                result.Result = "输入的密码不一致,或密码过长！";
                result.Content = false;
                return result;
            }
            #endregion

            var isAny = await _userServices.IsAny(t=>t.loginName == obj.loginName);
            if (isAny) {
                result.ret = 1;
                result.Result = "已存在该用户名！";
                result.Content = false;
                return result;
            }

            var passkey = RandomHelper.GetRandomString(6, true, true, true, true, "");
            var passvalue = MD5Helper.MD5Encrypt32($"{obj.repass}{passkey}");
            Shop_sys_user _user = new Shop_sys_user() {
                birthday = DateTime.Now,
                creatTime = DateTime.Now,
                Email = obj.loginName,
                LastLogin = DateTime.Now,
                loginName = obj.loginName,
                headPortrait = "",
                LoginNum = 0,
                Mobile = obj.mobilePhone,
                nickName = obj.loginName,
                passkey = passkey,
                passValue = passvalue,
                qq_code = "",
                realName = obj.loginName,
                regRemarks = "",
                sex = 1,
                uStatus = 1,
                wx_openid = "",

            };
            var uid = await _userServices.Add(_user);
            if (uid != 0)
            {
                //插入
                await _User_LogServices.AddUserLogAsync(uid,2,$"{obj.loginName}注册用户",obj.source);
                result.ret = 0;
                result.Result = "注册成功！";
                result.Content = true;
            }
            else {
                result.ret = 3;
                result.Result = "系统繁忙，稍后再试！";
                result.Content = false;
            }
            return result;
        }
        #endregion
    }
}