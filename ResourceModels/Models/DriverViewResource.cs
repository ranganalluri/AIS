namespace ResourceModels.Models
{
    public class DriverViewResource:BaseViewResource
    {
        public DriverItem DriverInformation { set; get; }
    }

    public class DriverItem
    {
        public string Id { set; get; }
        public string Name { set; get; }
        public string Dob { set; get; }
        public string MaritalStatus { set; get; }
    }
}