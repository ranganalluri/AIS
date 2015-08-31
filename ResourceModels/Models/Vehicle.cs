using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceModels.Models
{
    public  class Vehicle:HalResourceModel
    {
        public int Id { set; get; }
        public string Year { set; get; }
        public string Make { set; get; }
        public string Model { set; get; }
        public bool MoreToAdd { set; get; }
        public bool IsEdit { set; get; }
        public bool IsDelete { set; get; }
    }
}
