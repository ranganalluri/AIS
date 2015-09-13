using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Ajax.Utilities;

namespace APP.Controllers
{
    public class LookupController : ApiController
    {
        [HttpGet]
        [Route("api/lookup/GetYears/{key}")]
        public List<string> GetYears(string key)
        {
            HttpConfiguration config = GlobalConfiguration.Configuration;
            var api = config.Services.GetApiExplorer().ApiDescriptions.Distinct();
            foreach (var apiDescription in api)
            {
                string id = null;
               
                var path = apiDescription.RelativePath;
                id = string.Format(" public const string {0}{1}=", apiDescription.ActionDescriptor.ActionName,
                    apiDescription.ActionDescriptor.ControllerDescriptor.ControllerName) + "\"" + path + "\";";
                Debug.Print(id);
            }
            return new List<string>() { "2001", "2002", "2003" };
        }

        [HttpGet]
        [Route("api/lookup/Getmakes/{key}/{year}")]
        public List<string> Getmakes(string key,string year)
        {
            return new List<string>() { "Audi", "Audi1", "Audi2" };
        }

        [HttpGet]
        [Route("api/lookup/GetModel/{key}/{year}/{make}")]
        public List<string> GetModel(string key,string year,string make="")
        {
            return new List<string>() { "A1", "A2", "A3" };
        }

       
    }
}
