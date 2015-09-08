using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using APP.Processors;
using APP.Validators;
using APP.Extensions;
using ResourceModels.DomainModel;
using ResourceModels.Enums;
using ResourceModels.Models;
using AutoMapper;
namespace APP.Controllers
{
    public class VehicleController : BaseController
    {
        //// GET: api/Vehicle
        //public HalResource<VehcleModel> Get()
        //{
        //    return new HalResource<VehcleModel>() { };
        //}

        // GET: api/Vehicle/5
        public VehcleViewResource Get(string key,int id=0,bool? isDelete=null,bool? isEdit=null)
        {
            var policy = (PolicyContainer)HttpContext.Current.Cache["policy-" + key];
            var returnResource = new VehcleViewResource();

           returnResource.Vehcile=new Vehicle();

            BuildSwmmary(policy, returnResource);

            if (policy.Vehcles.Count == 1)
            {
                returnResource.Vehcile = policy.Vehcles[0];
                
            }
           

            return returnResource;
        }

        private void BuildSwmmary(PolicyContainer policy, VehcleViewResource returnResource)
        {
            if (policy.Vehcles.Count > 1)
            {
                returnResource.VehcileSummary = new List<VehicleSummary>();
                foreach (var vehicle in policy.Vehcles)
                {
                    int index = 1;
                    var summary = Mapper.Map<VehicleSummary>(vehicle);
                    summary.Links.Add(new Link()
                    {
                        Href = Url.Link("DefaultApi", new {controller = "Vehicle", id = index}),Title = "edit-vehicle"
                        
                    });
                    summary.Links.Add(new Link()
                    {
                        Href = Url.Link("DefaultApi", new {controller = "Vehicle", id = index}),
                        Title = "delete-vehicle"
                    });
                    index++;
                    returnResource.VehcileSummary.Add(summary);
                }
                returnResource.Vehcile = policy.Vehcles[0];
            }
        }

        // POST: api/Vehicle
        public HttpResponseMessage Post(string key,Vehicle value,int id=0)
        {
            var error = new ModelCustomValidator<Vehicle>().Validate1(value);

            var policy = (PolicyContainer)HttpContext.Current.Cache["policy-" + key];
            value.Id = id;
            if (policy != null)
            {
               policy.Vehcles.Add(value);
            }

            HttpContext.Current.Cache.Insert("policy-" + key, policy);

            var host = Request.GetHeader("ApiHost");
            var returnvalue = new VehcleViewResource();

            
            returnvalue.Vehcile = value;
            BuildSwmmary(policy,returnvalue);
            var hal = new HalPorcessor(null, PageType.Vehicle, host, key, Url);

            BuildLinks(value, returnvalue);

            returnvalue.Links = hal.FillInitialHalList();
            return Request.CreateResponse(HttpStatusCode.OK,returnvalue);
        }

        private void BuildLinks(Vehicle value, VehcleViewResource returnvalue)
        {
            if (!value.MoreToAdd)
                returnvalue.Vehcile.Links.Add(new Link()
                {
                    Href = Url.Link("DefaultApi", new {controller = "Driver", key = "icliq"}),
                    Title = "next driver-node"
                });
            returnvalue.Vehcile.Links.Add(new Link()
            {
                Href = Url.Link("DefaultApi", new {controller = "Vehicle", key = "icliq"}),
                Title = "vehicle-node"
            });
        }

        // PUT: api/Vehicle/5
        public void Put(string key,int id, VehcleViewResource value)
        {
        }

        // DELETE: api/Vehicle/5
        public void Delete(string key,int id)
        {
        }
    }
}
