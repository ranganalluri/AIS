using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using DataAccess.Extensions;
using DataAccess.Processors;
using DataAccess.Validators;
using ResourceModels.DomainModel;
using ResourceModels.Enums;
using ResourceModels.Models;
using AutoMapper;
namespace DataAccess.Controllers
{
    public class VehicleController : ApiController
    {
        // GET: api/Vehicle
        public HalResource<VehcleModel> Get()
        {
            return new HalResource<VehcleModel>() { };
        }

        // GET: api/Vehicle/5
        public HalResource<VehcleModel> Get(string key,int id=0)
        {
            var policy = (PolicyContainer)HttpContext.Current.Cache["policy-" + key];
            var returnResource = new HalResource<VehcleModel>();

           returnResource.Resource=new VehcleModel();

            BuildSwmmary(policy, returnResource);

            if (policy.Vehcles.Count == 1)
            {
                returnResource.Resource.Vehcile = policy.Vehcles[0];
                
            }
           

            return returnResource;
        }

        private void BuildSwmmary(PolicyContainer policy, HalResource<VehcleModel> returnResource)
        {
            if (policy.Vehcles.Count > 1)
            {
                returnResource.Resource.VehcileSummary = new List<VehicleSummary>();
                foreach (var vehicle in policy.Vehcles)
                {
                    int index = 1;
                    var summary = Mapper.Map<VehicleSummary>(vehicle);
                    summary.Links.Add(new Link()
                    {
                        Href = Url.Link("DefaultApi", new {controller = "Vehicle", id = index}),
                        NodeName = "edit-vehicle"
                    });
                    summary.Links.Add(new Link()
                    {
                        Href = Url.Link("DefaultApi", new {controller = "Vehicle", id = index}),
                        NodeName = "delete-vehicle"
                    });
                    index++;
                    returnResource.Resource.VehcileSummary.Add(summary);
                }
                returnResource.Resource.Vehcile = policy.Vehcles[0];
            }
        }

        // POST: api/Vehicle
        public HalResource<VehcleModel> Post(string key,Vehicle value,int id=0)
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
            var returnvalue = new HalResource<VehcleModel>();

            returnvalue.Resource=new VehcleModel();
            returnvalue.Resource.Vehcile = value;
           BuildSwmmary(policy,returnvalue);
            var hal = new HalPorcessor(null, PageType.Vehicle, host, key, Url);
            returnvalue.Resource.Links = hal.BuildHalResource();
            returnvalue.Links = hal.FillInitialHalList();
            return returnvalue;
        }

        // PUT: api/Vehicle/5
        public void Put(string key,int id, VehcleModel value)
        {
        }

        // DELETE: api/Vehicle/5
        public void Delete(string key,int id)
        {
        }
    }
}
