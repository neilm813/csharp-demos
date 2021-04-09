using System.Collections.Generic;

namespace TravelGuide.Models
{
    // Wrapper class so that we can pass all of the below data to a page as a view model
    public class GuidePage
    {
        public Traveler Traveler { get; set; }
        public List<Destination> Destinations { get; set; }
    }
}