using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using ResourceModels.DomainModel;
using ResourceModels.Models;

namespace APP.Controllers
{
    public class DriverController : BaseController
    {
        //// GET: api/Driver
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/Driver/5
        public DriverViewResource Get(string key, int id = 0)
        {
            var policy = (PolicyContainer)HttpContext.Current.Cache["policy-" + key];

            var returnResource = new DriverViewResource
            {
                DriverInformation = new DriverItem {Name = policy.Customer.Name, Dob = policy.Customer.DOB}
            };

            //returnResource.Resource.MaritalStatus=
           

            return returnResource;
        }

        // POST: api/Driver
        public void Post(string key,DriverViewResource driver)
        {
        }

        // PUT: api/Driver/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Driver/5
        public void Delete(int id)
        {
        }
    }
}
