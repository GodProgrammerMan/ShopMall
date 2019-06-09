using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopMall.Common;
using ShopMall.Common.Helper;
using ShopMall.IServices;
using ShopMall.Model;
using ShopMall.Model.Models;
using ShopMall.Model.ViewModels;

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
        /// <param name="ID"></param>
        /// <returns></returns>
        [Route("loginshop")]
        [HttpPost]
        public async Task<JsonResult<LoginUserDTO>> ShopMallLogin([FromBody] int ID)
        {
            var model = new JsonResult<LoginUserDTO>();
            var user = await _userServices.QueryById(ID);
            try
            {
                string parameters = @"{ ""username"": ""wjk"",""password"": ""123"",""grant_type"": ""password"",""client_id"": ""client2"",""client_secret"": ""secret""}";
                var loginMsg = GetNetData.Post("http://lzxidentityserver.com/", parameters);
                model.Result = "获取成功！";
            }
            catch (Exception e)
            {
                model.Result = "e:"+ e;
            }


            return new BaseJsonResult().UnifiedFucn(() =>
            { 
                model.Success = true;

                model.Content = null;
                return model;
            });
        }
    }
}