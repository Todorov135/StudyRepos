using System;

namespace _03._Extract_File
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split("\\");
            string currFolder = input[input.Length - 1];
            string[] fileOverview = currFolder.Split(".");
            Console.WriteLine($"File name: {fileOverview[0]}");
            Console.WriteLine($"File extension: {fileOverview[1]}");
        }
    }
}
