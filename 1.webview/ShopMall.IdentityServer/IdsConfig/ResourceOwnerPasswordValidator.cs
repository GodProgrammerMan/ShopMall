using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using ShopMall.Common;
using ShopMall.IServices;
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
            //根据context.UserName和context.Password与数据库的数据做校验，判断是否合法
            if (context.UserName=="wjk"&&context.Password=="123")
            {
                context.Result = new GrantValidationResult(
                 subject: context.UserName,
                 authenticationMethod: "custom",
                 claims: GetUserClaims());
            }
            else
            {
                
                 //验证失败
                 context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "invalid custom credential");
            }
        }
        //可以根据需要设置相应的Claim
        private Claim[] GetUserClaims()
        {
            return new Claim[]
            {
            new Claim("UserId", 1.ToString()),
            new Claim(JwtClaimTypes.Name,"wjk"),
            new Claim(JwtClaimTypes.GivenName, "jaycewu"),
            new Claim(JwtClaimTypes.FamilyName, "yyy"),
            new Claim(JwtClaimTypes.Email, "977865769@qq.com"),
            new Claim(JwtClaimTypes.Role,"admin")
            };
        }
    }
}
