namespace ResourceModels.Models
{
    public class VehcleModel:HalResourceModel
    {
        public string Year { set; get; }
        public string Make { set; get; }
        public string Model { set; get; }
    }
}