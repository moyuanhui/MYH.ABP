using Microsoft.AspNetCore.Hosting;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace MYH.ABP.Web.Host.Startup
{
    public class SwaggerCustomUIFiliter : IDocumentFilter
    {
        /// <summary>
        /// 缓存字典
        /// </summary>
        private readonly ConcurrentDictionary<string, string> m_cacheDictionary = new ConcurrentDictionary<string, string>();
        private readonly IHostingEnvironment m_environment;

        public SwaggerCustomUIFiliter(IHostingEnvironment env)
        {
            m_environment = env;
        }

        public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
        {
            string _xmlDir = Path.Combine(m_environment.ContentRootPath, "doc");

            foreach (var _path in Directory.GetFiles(_xmlDir, "*.xml"))
            {
                SetContorllerDescription(_path);
            }

            swaggerDoc.Extensions.TryAdd("ControllerDescription", m_cacheDictionary);
        }

        private void SetContorllerDescription(string xmlPath)
        {
            if (File.Exists(xmlPath))
            {
                XmlDocument _xmlDoc = new XmlDocument();
                _xmlDoc.Load(xmlPath);

                Dictionary<string, string> _dict = new Dictionary<string, string>();

                string _type = string.Empty, _path = string.Empty, _controllerName = string.Empty;
                XmlNode _summaryNode = null;

                foreach (XmlNode _node in _xmlDoc.SelectNodes("//member"))
                {
                    _type = _node.Attributes["name"].Value;

                    if (_type.StartsWith("T:")
                        && !_type.Contains("T:MYH.MYHAppServiceBase")
                        && !_type.Contains("T:MYH.Net.MimeTypes.MimeTypeNames")
                        && _type.Contains("AppService"))
                    {
                        _summaryNode = _node.SelectSingleNode("summary");
                        string[] _names = _type.Split('.');
                        string _key = _names[_names.Length - 1];
                        if (_key.IndexOf("AppService", _key.Length - "AppService".Length, StringComparison.Ordinal) > -1)
                        {
                            _key = _key.Substring(0, _key.Length - "AppService".Length);
                        }

                        if (_summaryNode != null && !string.IsNullOrEmpty(_summaryNode.InnerText) && !m_cacheDictionary.ContainsKey(_key))
                        {
                            m_cacheDictionary.TryAdd(_key, _summaryNode.InnerText.Trim());
                        }
                    }
                }
            }
        }
    }
}
