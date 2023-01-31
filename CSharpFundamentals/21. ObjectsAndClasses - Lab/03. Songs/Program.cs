using System;
using System.Collections.Generic;

namespace _03._Songs
{
     class Program
    {
        static void Main(string[] args)
        {
            int numberOfSong = int.Parse(Console.ReadLine());
            List<Song> songs = new List<Song>();

            for (int i = 0; i < numberOfSong; i++)
            {
                string[] songsData = Console.ReadLine().Split('_');
                Song song = new Song(songsData[0], songsData[1], songsData[2]);
                songs.Add(song);    
            }
            string sortByTipeOrAll = Console.ReadLine();

            if (sortByTipeOrAll == "all")
            {
                foreach (Song song in songs)
                {
                    Console.WriteLine(song.Name);
                }
            }
            else
            {
                foreach (Song song in songs)
                {
                    if (song.TipeList == sortByTipeOrAll)
                    {
                        Console.WriteLine(song.Name);
                    }
                }
            }
        }
    }
    class Song
    {
        public Song(string tipeList, string name, string time)
        {
            this.TipeList = tipeList;
            this.Name = name;
            this.Time = time;
        }
    
        public string TipeList { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
    }
}
