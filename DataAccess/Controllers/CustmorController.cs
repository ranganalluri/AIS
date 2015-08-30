using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;
using DataAccess.Extensions;
using DataAccess.Validators;
using ResourceModels.DomainModel;
using ResourceModels.Models;

namespace DataAccess.Controllers
{
    public class CustomerController : ApiController
    {
        // GET: api/Custmor
        public HalResource<Customer> Get()
        {
            return null;
            
            // return new HalResource<Customer>(){Resource = new Customer(){DOB = "12",Id="1",Name = "ranga"},Link = "",Rel ="self"};
        }

        // GET: api/Custmor/5
        public HalResource<Customer> Get(string key)
        {
          var policy= (PolicyContainer)HttpContext.Current.Cache["policy-" + key];
        
          HttpContext.Current.Cache.Insert("policy-" + key, policy);

            var links = GetBaseNodes(key, "customer");
            if (policy == null || policy.Customer == null)
            {
                return new HalResource<Customer>()
                {
                    Resource = new Customer() {  },
                    _links = links
                };
            }

            //TODO we need to verify state is avialble customer in session if not return empty customer from builder
            return new HalResource<Customer>()
            {
                Resource = policy.Customer,               
                _links = links
            };


        }

        private List<BaseNode> GetBaseNodes(string key,string pageName)
        {
            var nodes = new List<BaseNode>();
            var host = Request.GetHeader("ApiHost");


            var link = string.Format("{0}api/{1}/{2}", host,pageName, new Guid(key));          

           // HttpContext.Current.Cache.Insert("policy-" + key, policy);

            nodes.Add(new BaseNode() { nodename = "next vehicle", _links = new List<Link>() { new Link() { href = link, name = "customernode" } } });
            nodes.Add(new BaseNode() { nodename = "recall", _links = new List<Link>() { new Link() { href = link, name = "customernode" } } });
          

            return nodes;
        }

        // POST: api/Custmor
        public HalResource<Customer> Post(string key, Customer value)
        {
            var error = new ModelCustomValidator<Customer>().Validate1(value);
            var links = GetBaseNodes(key, "vehcile");
            return new HalResource<Customer>()
            {
                Resource = new Customer() { },
                _links = links
            };

        }

      
    }
}
