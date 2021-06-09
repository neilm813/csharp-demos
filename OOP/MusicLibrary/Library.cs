using System.Collections.Generic;

namespace MusicLibrary
{
    public class Library
    {
        public List<Song> Songs { get; set; } = new List<Song>();
        public List<Playlist> Playlists { get; set; } = new List<Playlist>();

        public Song AddSong(Song newSong)
        {
            Songs.Add(newSong);
            return newSong;
        }
    }
}