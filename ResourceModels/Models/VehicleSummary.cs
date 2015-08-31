using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceModels.Models
{
    public class VehicleSummary:HalResourceModel
    {
        public int Id { set; get; }
        public string Year { set; get; }
        public string Make { set; get; }
        public string Model { set; get; }
        public string Edit { set; get; }
        public string Delete { set; get; }

        public VehicleSummary()
        {
            Edit = "edit-vehicle";
            Delete = "delete-vehicle";
        }
    }
}
