using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace WebAPI.FilterClass
{ 
    public class AuthTokenHeaderParameter:IOperationFilter
    {

        public void Apply(Operation operation, OperationFilterContext context)
        {
            SetContorllerDescription(operation.Extensions);

            operation.Parameters = operation.Parameters ?? new List<IParameter>();
            //MemberAuthorizeAttribute 自定义的身份验证特性标记
            var isAuthor = operation != null && context != null;
            if (isAuthor)
            {
                //in query header 
                operation.Parameters.Add(new NonBodyParameter()
                {
                    Name = "Authorization",
                    In = "header", //增加头部token验证
                    Description = "token验证",
                    Required = true,
                    Type = "string"
                });
            }
        }

        private void SetContorllerDescription(Dictionary<string, object> extensionsDict)
        {
            string _xmlPath = Path.Combine(Directory.GetCurrentDirectory(), "HKERP.Application.xml");
            ConcurrentDictionary<string, string> _controllerDescDict = new ConcurrentDictionary<string, string>();
            if (File.Exists(_xmlPath))
            {
                XmlDocument _xmlDoc = new XmlDocument();
                _xmlDoc.Load(_xmlPath);
                string _type = string.Empty, _path = string.Empty, _controllerName = string.Empty;
                XmlNode _summaryNode = null;
                foreach (XmlNode _node in _xmlDoc.SelectNodes("//member"))
                {
                    _type = _node.Attributes["name"].Value;
                    if (_type.StartsWith("T:") && !_type.Contains("T:HKERP.HKERPAppServiceBase") && !_type.Contains("T:HKERP.Net.MimeTypes.MimeTypeNames"))
                    {
                        _summaryNode = _node.SelectSingleNode("summary");
                        string[] _names = _type.Split('.');
                        string _key = _names[_names.Length - 1];
                        if (_key.IndexOf("AppService", _key.Length - "AppService".Length, StringComparison.Ordinal) > -1)
                        {
                            _key = _key.Substring(0, _key.Length - "AppService".Length);
                        }
                        if (_summaryNode != null && !string.IsNullOrEmpty(_summaryNode.InnerText) && !_controllerDescDict.ContainsKey(_key))
                        {
                            _controllerDescDict.TryAdd(_key, _summaryNode.InnerText.Trim());
                        }
                    }
                }
                extensionsDict.TryAdd("ControllerDescription", _controllerDescDict);
            }
        }
    }
}
