using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using ShopMall.Common;
using ShopMall.Common.Helper;
using ShopMall.IServices;
using ShopMall.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ShopMall.IdentityServer.IdsConfig
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        readonly IShop_sys_userServices _userServices;
        readonly IRedisCacheManager _redisCacheManager;

        public ResourceOwnerPasswordValidator(IShop_sys_userServices userServices, IRedisCacheManager redisCacheManager)
        {
            _userServices = userServices;
            _redisCacheManager = redisCacheManager;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            Shop_sys_user user = new Shop_sys_user();
            //获取用户
            try
            {
                if (_redisCacheManager.Get<object>("Redis.sysuser") != null)
                {
                    user = _redisCacheManager.Get<Shop_sys_user>("Redis.sysuser");
                }
                else
                {
                    user = await _userServices.GetSysUserByLoginNameAsync(context.UserName);
                    _redisCacheManager.Set("Redis.sysuser", user, TimeSpan.FromHours(10));
                }

            }
            catch (Exception e)
            {
                _redisCacheManager.Set("Redis.sysuser", user, TimeSpan.FromHours(10));
            }
            if (user != null)
            {
                if (user.uStatus == 0) {
                    context.Result = new GrantValidationResult(TokenRequestErrors.InvalidClient, "密码不正确！");
                    return;
                }
                var _pass = context.Password + user.passkey;
                var _md5passkey = MD5Helper.MD5Encrypt32(_pass);
                if (_md5passkey.Equals(user.passValue))
                {
                    context.Result = new GrantValidationResult(
                     subject: context.UserName,
                     authenticationMethod: "custom",
                     claims: new Claim[]
                        {
                            new Claim("uid", user.uid+""),
                            new Claim(JwtClaimTypes.Name,user.loginName),
                            new Claim(JwtClaimTypes.GivenName, user.realName),
                            new Claim(JwtClaimTypes.FamilyName, user.nickName),
                            new Claim(JwtClaimTypes.Email, string.IsNullOrWhiteSpace(user.Email)?"":user.Email ),
                            new Claim(JwtClaimTypes.Role,"user")
                        });
                    return;
                }
                else
                {
                    context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "密码不正确！");
                    return;
                }
            }
            else
            {
                //验证失败
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "不存在该用户名！");
                return;
            }
        }
    }
}
