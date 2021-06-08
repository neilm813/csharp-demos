using System;
using System.Collections.Generic;

namespace MusicLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 
            User, user creates playlist, user adds song to playlist
            Songs, Playlists, SongLibrary, shuffle playlist, find songs by name contains, playlist duration
            */

            Library library = new Library();

            Artist dimash = new Artist("Dimash Kudaibergen", 2005);

            Artist bonobo = new Artist("Bonobo", 1999);

            Artist gammer = new Artist("Gammer", 2001);

            library.AddSong(new Song("SOS", 300, dimash));

            library.AddSong(new Song("Sinful Passion", 350, dimash));

            library.AddSong(new Song("Animals", 425, bonobo));

            library.AddSong(new Song("Migration", 328, bonobo));

            library.AddSong(new Song("The Drop", 230, gammer));

            library.AddSong(new Song("Sleep At Night", 320, gammer));

            Playlist playlist1 = new Playlist("Best singers.", " In the whole wide world!");

            Playlist playlist2 = new Playlist("Chill lofi beats to hip and hop to.", "Good for chilling, studying, background music, and to impress your friends with your superior musical taste.");

            playlist1.AddSong("SOS", library);
            playlist1.AddSong("Sinful Passion", library);
            playlist2.AddSong("Animals", library);
            playlist2.AddSong("Migration", library);
            playlist2.AddSong("The Drop", library);
            playlist2.AddSong("Sleep At Nightt", library);

            library.Playlists.Add(playlist1);
            library.Playlists.Add(playlist2);

            Console.WriteLine("Yay music");
        }
    }
}
