namespace TravelGuide.Models
{
    public class Destination
    {
        public string Name { get; set; }
        public string ImgUrl { get; set; }

        public Destination(string name = "", string imgUrl = "")
        {
            Name = name;
            ImgUrl = imgUrl;
        }
    }
}