using System;
using System.Text.RegularExpressions;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = "Nakov: 123";
            string pattern = @"([A-Z][a-z]+): (\d+)";
          
            Match match = Regex.Match(text, pattern);

            Console.WriteLine(match.Groups.Count); // 3
            Console.WriteLine("Matched text: \"{0}\"", match.Groups[0]);
            Console.WriteLine("Name: {0}", match.Groups[1]); // Nakov
            Console.WriteLine("Number: {0}", match.Groups[2]); // 123
        }
    }
}
