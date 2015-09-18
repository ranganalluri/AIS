using System.Collections.Generic;
using System.Web;
using ResourceModels.Models;

namespace ResourceModels.DomainModel
{
    public class PolicyContainer:IPolicyContainer
    {
        public string Key { set; get; }
        public string ApiHost { set; get; }
        public Customer Customer { set; get; }
        public List<Vehicle> Vehcles { set; get; }
        public List<DriverItem> Drivers { set; get; }
      

        public PolicyContainer()
        {
            Vehcles=new List<Vehicle>();
            Drivers=new List<DriverItem>();
        }

        
        public PolicyContainer GetPolicy(string key)
        {
           return (PolicyContainer)HttpContext.Current.Cache["policy-" + key];
        }


        public DriverItem GetDriver(int id)
        {
            throw new System.NotImplementedException();
        }


        public Vehicle GetVehicle(int id)
        {
            throw new System.NotImplementedException();
        }


        public void SavePolicy(string key,PolicyContainer policy)
        {
            HttpContext.Current.Cache.Insert("policy-" + key, policy);
        }


        public void SavePolicy(string key)
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IPolicyContainer
    {
        PolicyContainer GetPolicy(string key);
        DriverItem GetDriver(int id);
        Vehicle GetVehicle(int id);
        void SavePolicy(string key);

    }
}