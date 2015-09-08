using System.Collections.Generic;

namespace ResourceModels.Models
{
    public class VehcleViewResource:BaseViewResource
    {
        public Vehicle Vehcile { set; get; }
        public List<VehicleSummary> VehcileSummary { set; get; }
    }
}