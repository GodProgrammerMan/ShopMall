using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.FilterClass  
{
    public class AuthApplyTagDescriptions: IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
        {
            swaggerDoc.Tags = new List<Tag>
            {  
                new Tag{ Name="ShopMall WebApi",Description="ShopMall 服务接口"},
            };
        }
    }
}
