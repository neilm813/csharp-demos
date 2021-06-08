namespace MusicLibrary
{
    public class Artist
    {
        // Name of solo artist or band.
        public string Name { get; set; }
        public int YearEstablished { get; set; }

        public Artist(string name, int yearEstablished)
        {
            Name = name;
            YearEstablished = yearEstablished;
        }
    }

}