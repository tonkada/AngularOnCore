using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Xml;

namespace AngularOnCore.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        /// <summary>
        /// The API URL
        /// </summary>
        public const string API_URL = "http://thecatapi.com/api/";

        /// <summary>
        /// Calling rest api and converting the result from xml to json.
        /// </summary>
        /// <returns>
        /// Json list of categories.
        /// </returns>
        [HttpGet("[action]")]
        public object GetCategories()
        {
            string url = API_URL + "categories/list";
            var doc = new XmlDocument();
            var result = new List<object>();

            WebRequest request = WebRequest.Create(url);
            try
            {
                WebResponse response = request.GetResponse();
                using (var sr = new System.IO.StreamReader(response.GetResponseStream()))
                {
                    try
                    {
                        doc.LoadXml(sr.ReadToEnd());

                        XmlNodeList listOfCategories = doc.SelectNodes("/response/data/categories/category");
                        foreach (XmlNode singleCategory in listOfCategories)
                        {
                            string id = singleCategory.SelectSingleNode("id").InnerText;
                            string name = singleCategory.SelectSingleNode("name").InnerText;
                            result.Add(new { id, name });
                        }

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

            return result;
        }



    }
}
