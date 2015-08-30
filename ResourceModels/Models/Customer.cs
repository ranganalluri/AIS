namespace ResourceModels.Models
{
    public class Customer:HalResourceModel
    {
        public string Id { set; get; }
        public string Name { set; get; }
        public string DOB { set; get; }
      
    }
}