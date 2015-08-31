using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;
using System.Web.Http.Routing;
using DataAccess.Extensions;
using DataAccess.Processors;
using DataAccess.Validators;
using ResourceModels.DomainModel;
using ResourceModels.Enums;
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
        public HalResource<Customer> Get(string key,int id=0)
        {          
          var policy= (PolicyContainer)HttpContext.Current.Cache["policy-" + key];

          var returnvalue = new HalResource<Customer> { Resource = new Customer() };

            var host = Request.GetHeader("ApiHost");
            if (policy != null && policy.Customer!=null)
            {
                returnvalue.Resource = policy.Customer;
            }
            

            var hal = new HalPorcessor(null, PageType.Customer, host, key, Url);
             returnvalue.Resource.Links= hal.BuildHalResource();
            returnvalue.Links = hal.FillInitialHalList();
            //TODO we need to verify state is avialble customer in session if not return empty customer from builder

            return returnvalue;


        }       

        // POST: api/Custmor
        public HalResource<Customer> Post(string key, Customer value)
        {
            var error = new ModelCustomValidator<Customer>().Validate1(value);

            var policy = (PolicyContainer)HttpContext.Current.Cache["policy-" + key];
            if (policy != null)
            {
                policy.Customer = value;
            }

            HttpContext.Current.Cache.Insert("policy-" + key, policy);

            var host = Request.GetHeader("ApiHost");
            var returnvalue = new HalResource<Customer> { Resource = value };

            var hal = new HalPorcessor(null, PageType.Customer, host, key, Url);
            returnvalue.Resource.Links = hal.BuildHalResource();
            returnvalue.Links = hal.FillInitialHalList();

            return returnvalue;
        }

      
    }
}
