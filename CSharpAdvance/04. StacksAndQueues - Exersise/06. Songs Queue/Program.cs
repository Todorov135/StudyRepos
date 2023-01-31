using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Songs_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> playlist = new Queue<string>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries));

            while (playlist.Count>0)
            {
                string command = Console.ReadLine();
                if (command.StartsWith("Play"))
                {
                    playlist.Dequeue();
                }
                else if (command.StartsWith("Add"))
                {
                    string songToAdd = command.Substring(4);
                    if (playlist.Contains(songToAdd))
                    {
                        Console.WriteLine($"{songToAdd} is already contained!");
                    }
                    else
                    {
                        playlist.Enqueue(songToAdd);
                    }
                }
                else if (command.StartsWith("Show"))
                {
                    Console.WriteLine(string.Join(", ", playlist));
                }
            }
            Console.WriteLine("No more songs!");
        }
    }
}
