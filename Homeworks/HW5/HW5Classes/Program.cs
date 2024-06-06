/*
Create a simple class with at least two private variables (fields) 
and corresponding get/set for those variables. The class should 
also have a constructor and at least one method in the class 
that does something. Demonstrate your class in Main with
at least 2 objects created from the class.
*/

using System;

namespace HW5Classes
{
    class Music
    {
        private string artist;
        private string album;
        private string song;

        public Music(string artist, string album, string song)
        {
            this.artist = artist;
            this.album = album;
            this.song = song;
        }

        //GETTERS
        public string GetArtist()
        {
            return artist;
        }
        public string GetAlbum()
        {
            return album;
        }
        public string GetSong()
        {
            return song;
        }

        //SETTERS
        public void SetArtist(string artist)
        {
            this.artist = artist;
        }
        public void SetAlbum(string album)
        {
            this.album = album;
        }
        public void SetSong(string song)
        {
            this.song = song;
        }
        
        //METHODS
        public void PrintMusic()
        {
            Console.WriteLine("Artist: " + artist);
            Console.WriteLine("Album: " + album);
            Console.WriteLine("Song: " + song);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string tempstring;
            string[] parsed_tempstring;
            // Create two objects of the class
            Console.WriteLine("Enter in the artist, album, and song title for a song, separated by a comma: ");
            tempstring = Console.ReadLine();
            parsed_tempstring = tempstring.Split(',');

            Music song1 = new Music(parsed_tempstring[0], parsed_tempstring[1], parsed_tempstring[2]);

            Console.WriteLine("Enter in the artist, album, and song title for a song: ");
            tempstring = Console.ReadLine();
            parsed_tempstring = tempstring.Split(',');

            Music song2 = new Music(parsed_tempstring[0], parsed_tempstring[1], parsed_tempstring[2]);


            // Print out the objects
            Console.WriteLine("Song 1: ");
            song1.PrintMusic();
            Console.WriteLine("Song 2: ");
            song2.PrintMusic();
        }
    }

}
