using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DataAccess.Controllers
{
    public class LookupController : ApiController
    {
        [HttpGet]
        public List<string> GetYears()
        {
            return new List<string>() { "2001", "2002", "2003" };
        }

        [HttpGet]
        [Route("api/lookup/Getmakes/{year}")]
        public List<string> Getmakes(string year)
        {
            return new List<string>() { "Audi", "Audi1", "Audi2" };
        }

        [HttpGet]
        [Route("api/lookup/getModel/{year}/{make}")]
        public List<string> GetModel(string year,string make="")
        {
            return new List<string>() { "A1", "A2", "A3" };
        }

       
    }
}
