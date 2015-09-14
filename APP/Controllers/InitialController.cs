using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;
using APP.Common;
using APP.Navigation;
using APP.Processors;
using APP.Extensions;
using ResourceModels.DomainModel;
using ResourceModels.Enums;
using ResourceModels.Models;

namespace APP.Controllers
{
    public class InitialController : BaseController
    {
        public InitialController(IWrokflowController workflowController)
            : base(workflowController)
        {
           
        } 
      
        //// GET: api/Initial/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Initial
        public List<Link> Post(ContextResource context)
        {
            var key = Guid.NewGuid().ToString();

           

            var host = Request.GetHeader("ApiHost");
            

            var link = string.Format("{0}api/Customer/{1}", host, key);
            var policy = new PolicyContainer { Key = key };
            HttpContext.Current.Cache.Insert("policy-" + key, policy);

            
            var halProcess = new HalPorcessor(context, PageType.Initial, host, key,Url);

            return halProcess.FillInitialHalList();

        }

    }
}
