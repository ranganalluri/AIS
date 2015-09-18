using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Routing;
using APP.Common;
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
        private readonly IBaseBuilder<CustomerViewResource> _builder; 

        public CustomerController(IWrokflowController workflowController,IBaseBuilder<CustomerViewResource> builder)
            : base(workflowController)
        {
            _builder = builder;
        }        
        public CustomerViewResource Get(string key,int id=0)
        {
            var policy= PolicyContainer.GetPolicy(key);
            policy.ApiHost = Request.GetHeader("ApiHost");
         
            var returnValue= _builder.Build(policy);
            var hal = new HalPorcessor(null, PageType.Customer, policy.ApiHost, key, Url);
            returnValue.CustomerInfo.Links = hal.BuildHalResource();


            returnValue.Links = hal.FillInitialHalList();
            return returnValue;

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

            var policy = PolicyContainer.GetPolicy(key);
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
