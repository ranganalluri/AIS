using System.Collections.Generic;

namespace ResourceModels.Models
{
    public class VehcleModel:HalResourceModel
    {
        public Vehicle Vehcile { set; get; }
        public List<VehicleSummary> VehcileSummary { set; get; }
    }
}