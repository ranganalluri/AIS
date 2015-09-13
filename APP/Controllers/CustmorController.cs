using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Routing;
using APP.Navigation;
using APP.Processors;
using APP.Validators;
using APP.Extensions;
using ResourceModels.DomainModel;
using ResourceModels.Enums;
using ResourceModels.Models;

namespace APP.Controllers
{
    public class CustomerController : BaseController
    {

        public CustomerController(INavigation navigation) : base(navigation)
        {
           
        }        
        public CustomerViewResource Get(string key,int id=0)
        {          
            
          var policy= (PolicyContainer)HttpContext.Current.Cache["policy-" + key];

            var returnvalue=new CustomerViewResource();
            
            var host = Request.GetHeader("ApiHost");
            if (policy != null && policy.Customer!=null)
            {
                returnvalue.CustomerInfo = policy.Customer;
            }
            else
            {
                returnvalue.CustomerInfo=new Customer();
            }
            var hal = new HalPorcessor(null, PageType.Customer, host, key, Url);
            returnvalue.CustomerInfo.Links = hal.BuildHalResource();
            

            returnvalue.Links = hal.FillInitialHalList();
            //TODO we need to verify state is avialble customer in session if not return empty customer from builder

            return returnvalue;


        }       

        // POST: api/Custmor
        public HttpResponseMessage Post(string key, Customer value)
        {
            HttpResponseMessage response = null;
            var error = base.ValidateModel(value);

            if (error.Count > 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, value);
            }
            var policy = (PolicyContainer)HttpContext.Current.Cache["policy-" + key];
            if (policy != null)
            {
                policy.Customer = value;
            }
            var returnvalue = value;
            HttpContext.Current.Cache.Insert("policy-" + key, policy);

            var host = Request.GetHeader("ApiHost");
            

            var hal = new HalPorcessor(null, PageType.Customer, host, key, Url);
            returnvalue.Links = hal.BuildHalResource();
                        
            return Request.CreateResponse(HttpStatusCode.OK, returnvalue);
        }

      
    }
}
