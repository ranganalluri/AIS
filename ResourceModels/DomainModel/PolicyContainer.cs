using ResourceModels.Models;

namespace ResourceModels.DomainModel
{
    public class PolicyContainer:IPolicyContainer
    {
        public string Key { set; get; }
        public Customer Customer { set; get; }
        public VehcleModel Vehcle { set; get; }
        public DriverViewResource Driver { set; get; }
        public INavigationResource Navigation { set; get; }
    }

    public interface IPolicyContainer
    {
        
    }
}