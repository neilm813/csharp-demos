namespace MusicLibrary
{
    public class Song
    {
        // Seconds
        public string Name { get; set; }
        public int Duration { get; set; }
        public Artist Artist { get; set; }

        public Song(string name, int duration, Artist artist)
        {
            Name = name;
            Duration = duration;
            Artist = artist;
        }
    }
}