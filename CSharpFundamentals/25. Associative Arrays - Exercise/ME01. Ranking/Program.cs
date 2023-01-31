using System;
using System.Collections.Generic;
using System.Linq;

namespace ME01._Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, string> contestPassSequence = new Dictionary<string, string>();

            while (input != "end of contests")
            {
                string[] contestAndPass = input.Split(":");
                contestPassSequence.Add(contestAndPass[0], contestAndPass[1]);
                input = Console.ReadLine();
            }
            Dictionary<string, Dictionary<string, int>> userInfo = new Dictionary <string, Dictionary<string, int>>();

            string input2 = Console.ReadLine();
            while (input2 != "end of submissions")
            {
                
                Dictionary<string, int> currUserInfo = new Dictionary<string, int>();

                string[] tokens = input2.Split("=>");
                string contest = tokens[0];
                string pass = tokens[1];
                string username = tokens[2];
                int points = int.Parse(tokens[3]);

                if (!contestPassSequence.ContainsKey(contest) || (contestPassSequence.ContainsKey(contest) && contestPassSequence[contest] != pass))
                {
                    break;

                }
                
                currUserInfo.Add(contest, points);
                userInfo.Add(username, currUserInfo);

                

                input2 = Console.ReadLine();
            }

            string bestUser = string.Empty;
            int maxScore = 0;

            foreach (var user in userInfo)
            {
                int sum = 0;
                foreach (var score in user.Value)
                {
                    sum += score.Value;
                }
                if (sum > maxScore)
                {
                    maxScore = sum;
                    bestUser = user.Key;
                }
            }
            Console.WriteLine($"Best candidate is {bestUser} with total {maxScore} points.");

            userInfo = userInfo.OrderBy(u => u.Key).ToDictionary(k => k.Key, v => v.Value);
            Console.WriteLine("Ranking:");
            foreach (var user in userInfo)
            {
                Console.WriteLine(user.Key);
                foreach (var item in user.Value.OrderByDescending(p=>p.Value))
                {
                    Console.WriteLine($"#  {item.Key} -> {item.Value}");
                }
            }
            


        }
    }
}
