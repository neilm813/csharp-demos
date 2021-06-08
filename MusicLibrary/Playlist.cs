using System.Collections.Generic;

namespace MusicLibrary
{
    public class Playlist
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Song> Songs { get; set; } = new List<Song>();

        public int TotalDuration 
        { 
            get
            {
                int total = 0;

                foreach (Song song in Songs)
                {
                    total += song.Duration;
                }
                
                return total;
            }
        }

        // This empty constructor lets you create an instance with all default prop values.
        public Playlist()
        {

        }

        public Playlist(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public Playlist(string name, string description, List<Song> songs)
        {
            Name = name;
            Description = description;
            Songs = songs;
        }

        public Song AddSong(string songName, Library library)
        {
            Song foundSong = library.Songs.Find(song => song.Name == songName);

            if (foundSong != null)
            {
                Songs.Add(foundSong);
            }

            return foundSong;
        }
    }
}