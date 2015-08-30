using System.Web.Http;
using ResourceModels.Models;

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
        public HalResource<VehcleModel> Get(int id)
        {
            return new HalResource<VehcleModel>()
            {
                Resource = new VehcleModel() {Make = "Audi1", Model = "A1", Year = "2003"}
            };
        }

        // POST: api/Vehicle
        public void Post(VehcleModel value)
        {
        }

        // PUT: api/Vehicle/5
        public void Put(int id, VehcleModel value)
        {
        }

        // DELETE: api/Vehicle/5
        public void Delete(int id)
        {
        }
    }
}
