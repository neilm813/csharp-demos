namespace TravelGuide.Models
{
    public class Traveler
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // in ASP.NET if you create your own constructor your MUST add back the default empty constructor
        // public Traveler() { }

        public string FullName()
        {
            return FirstName + " " + LastName;
        }
    }
}