namespace ResourceModels.Models
{
    public class DriverViewResource:HalResourceModel
    {
        public string Id { set; get; }
        public string Name { set; get; }
        public string Dob { set; get; }
        public string MaritalStatus { set; get; }
    }
}