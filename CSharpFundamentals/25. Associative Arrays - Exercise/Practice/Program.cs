using System;
using System.Collections.Generic;
using System.Linq;

namespace Ranking_MoreEx
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(":");

            Dictionary<string, string> contest = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> student = new Dictionary<string, Dictionary<string, int>>();

            //C# Fundamentals=>fundPass=>Tanya=>350

            while (input[0] != "end of contests")
            {
                if (!contest.ContainsKey(input[0]))
                {
                    contest.Add(input[0], input[1]);
                }

                input = Console.ReadLine().Split(":");
            }

            string[] command = Console.ReadLine().Split("=>");

            while (command[0] != "end of submissions")
            {
                if (contest.ContainsKey(command[0]) && contest[command[0]] == command[1])
                {
                    if (!student.ContainsKey(command[2]))
                    {
                        student.Add(command[2], new Dictionary<string, int>());


                        student[command[2]].Add(command[0], int.Parse(command[3]));
                    }
                    else
                    {
                        if (!student[command[2]].ContainsKey(command[0]))
                        {
                            student[command[2]].Add(command[0], int.Parse(command[3]));
                        }
                        else
                        {
                            if (student[command[2]][command[0]] < int.Parse(command[3]))
                            {
                                student[command[2]][command[0]] = int.Parse(command[3]);
                            }

                        }
                    }
                }

                command = Console.ReadLine().Split("=>");
            }

            string bestStudent = "";
            int highPoints = 0;


            foreach (var name in student)
            {
                int totalPoints = 0;
                foreach (var course in name.Value)
                {
                    totalPoints += course.Value;
                }
                if (totalPoints > highPoints)
                {
                    bestStudent = name.Key;
                    highPoints = totalPoints;
                }
            }


            Console.WriteLine($"Best candidate is {bestStudent} with total {highPoints} points.");
            student = student.OrderBy(x => x.Key).ToDictionary(k => k.Key, v => v.Value);
            Console.WriteLine("Ranking:");
            foreach (var name in student)
            {
                Console.WriteLine(name.Key);
                foreach (var course in name.Value.OrderByDescending(v => v.Value))
                {
                    Console.WriteLine($"#  {course.Key} -> {course.Value}");
                }

            }
        }
    }
}