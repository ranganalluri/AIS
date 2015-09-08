using System.Collections.Generic;
using ResourceModels.Models;

namespace ResourceModels.DomainModel
{
    public class PolicyContainer:IPolicyContainer
    {
        public string Key { set; get; }
        public Customer Customer { set; get; }
        public List<Vehicle> Vehcles { set; get; }
        public List<DriverItem> Drivers { set; get; }
      

        public PolicyContainer()
        {
            Vehcles=new List<Vehicle>();
            Drivers=new List<DriverItem>();
        }
    }

    public interface IPolicyContainer
    {
        
    }
}