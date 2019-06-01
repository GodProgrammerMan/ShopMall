using Microsoft.AspNetCore.Authorization;
using System;

namespace WebAPI.Authorization
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class TestAuthorizeAttribute: AuthorizeAttribute
    {
        
        public string Permission { get; set; }

        public TestAuthorizeAttribute(string permission)
        {
            Permission = permission;
        }

    }
}
