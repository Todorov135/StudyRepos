using System;
using System.Text.RegularExpressions;

namespace _03._Match_Dates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string patterns = @"(?<day>[0-9]{2})(?<separator>[\.\-\/])(?<month>[A-Z][a-z]{2})\k<separator>(?<year>[0-9]{4})";  
            string input = Console.ReadLine();

            MatchCollection matches = Regex.Matches(input, patterns);

            foreach (Match match in matches)
            {
                var day = match.Groups["day"].Value;
                var month = match.Groups["month"].Value;
                

                Console.WriteLine($"Day: {day}, Month: {month}, Year: {match.Groups["year"].Value}");
            }

        }
    }
}
