using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;
using DataAccess.Extensions;
using ResourceModels.DomainModel;
using ResourceModels.Models;

namespace DataAccess.Controllers
{
    public class InitialController : ApiController
    {
        // GET: api/Initial
        public void Get()
        {
          
        }

        // GET: api/Initial/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Initial
        public List<BaseNode> Post(ContextResource context)
        {
            var key = Guid.NewGuid().ToString("N");

            var links = new List<BaseNode>();

            var host = Request.GetHeader("ApiHost");
            

            var link = string.Format("{0}api/Customer/{1}", host, new Guid(key));
            var policy = new PolicyContainer { Key = key };

            HttpContext.Current.Cache.Insert("policy-" + key, policy);

            links.Add(new BaseNode() { nodename = "next customer", _links = new List<Link>() { new Link() { href = link, name = "customernode" } } });
            links.Add(new BaseNode() { nodename = "recall", _links = new List<Link>() { new Link() { href = link, name = "customernode" } } });
            return links;
        }

        // PUT: api/Initial/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Initial/5
        public void Delete(int id)
        {
        }
    }
}
