using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02._Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var listOfRacers = Console.ReadLine().Split(", ").ToList();

            string input = Console.ReadLine();
            string namePattern = @"[A-Za-z]";
            string distancePattern = @"[0-9]+";
            Dictionary<string, int> nameOfRacerAndDistance = new Dictionary<string, int>();
            int distance = 0;

            while (input != "end of race")
            {
                MatchCollection match = Regex.Matches(input, namePattern);
                MatchCollection matchDistance = Regex.Matches(input, distancePattern);

                string currName = string.Join("", match);
                string currDistance = string.Join("", matchDistance);

                if (listOfRacers.Contains(currName))
                {
                    distance = 0;
                    for (int i = 0; i < currDistance.Length; i++)
                    {
                        int currDistanceInLoop = int.Parse(currDistance[i].ToString());
                        distance += currDistanceInLoop;
                    }
                    if (!nameOfRacerAndDistance.ContainsKey(currName))
                    {
                        nameOfRacerAndDistance.Add(currName, distance);
                    }
                    else
                    {
                        nameOfRacerAndDistance[currName] += distance;
                    }

                }

                input = Console.ReadLine();
            }
            
            var result = nameOfRacerAndDistance.OrderByDescending(x => x.Value).Take(3);
            int count = 1;
            foreach (var item in result)
            {
                if (count == 1)
                {
                    Console.WriteLine($"1st place: {item.Key}");
                }
                else if (count== 2)
                {
                    Console.WriteLine($"2nd place: {item.Key}");
                }
                else
                {
                    Console.WriteLine($"3rd place: {item.Key}");
                }
                count++;
            }
        }
    }
}
