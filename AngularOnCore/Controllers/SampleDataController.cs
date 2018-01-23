using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AngularOnCore.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        [HttpGet("[action]")]
        public object GetCategories()
        {
            const string url = "http://thecatapi.com/api/categories/list";
            XmlDocument doc = new XmlDocument();

            WebRequest request = WebRequest.Create(url);
            try
            {
                WebResponse response = request.GetResponse();
                using (var sr = new System.IO.StreamReader(response.GetResponseStream()))
                {
                    try
                    {
                        doc.LoadXml(sr.ReadToEnd());
                    }
                    catch (Exception)
                    {
                        // handle if necessary
                    }
                }
            }
            catch (WebException)
            {
                // handle if necessary    
            }

            return JsonConvert.SerializeXmlNode(doc.SelectSingleNode("/response/data/categories"));
        }

    }
}
